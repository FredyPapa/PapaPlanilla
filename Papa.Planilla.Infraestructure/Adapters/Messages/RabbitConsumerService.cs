using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Papa.Planilla.Domain.Ports.Messages;
using Papa.Planilla.Infraestructure.Configuration.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Papa.Planilla.Infraestructure.Adapters.Messages
{
    public class RabbitConsumerService : IRabbitConsumerService
    {
        private readonly RabbitConfiguration _rabbitConfiguration;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RabbitConsumerService> _logger;

        public RabbitConsumerService(RabbitConfiguration rabbitConfiguration, IServiceScopeFactory scopeFactory, ILogger<RabbitConsumerService> logger)
        {
            _rabbitConfiguration = rabbitConfiguration;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task SubscribeAsync<TMessage>(string queueName, Func<IServiceProvider, TMessage, Task> onMessage)
        {
            var connection = await _rabbitConfiguration.GetConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            var exchange = $"{queueName}.exchange";

            await channel.ExchangeDeclareAsync(exchange, ExchangeType.Direct, durable: true);
            await channel.QueueDeclareAsync(queueName, durable: true, exclusive: false, autoDelete: false);
            await channel.QueueBindAsync(queueName, exchange, routingKey: queueName);
            await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 10, global: false);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (_, eventArgs) =>
            {
                try
                {
                    var body = eventArgs.Body.ToArray();
                    var jsonOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Permite mapear sin importar minúsculas/mayúsculas
                    };
                    var message = JsonSerializer.Deserialize<TMessage>(body, jsonOptions);
                    using var scope = _scopeFactory.CreateScope();
                    await onMessage(scope.ServiceProvider, message!);
                    await channel.BasicAckAsync(eventArgs.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error procesando mensaje de la cola o queue {QueueName}", queueName);
                    await channel.BasicNackAsync(eventArgs.DeliveryTag, false, true);
                }
            };
            await channel.BasicConsumeAsync(queueName, autoAck: false, consumer);
        }
    }
}
