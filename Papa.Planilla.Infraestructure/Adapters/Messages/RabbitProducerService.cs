using Papa.Planilla.Domain.Model.Messages;
using Papa.Planilla.Domain.Ports.Messages;
using Papa.Planilla.Infraestructure.Configuration.Messages;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Papa.Planilla.Infraestructure.Adapters.Messages
{
    public class RabbitProducerService : IRabbitProducerService
    {
        private readonly RabbitConfiguration _rabbitConfiguration;

        public RabbitProducerService(RabbitConfiguration rabbitConfiguration)
        {
            _rabbitConfiguration = rabbitConfiguration;
        }

        public async Task PublishAsync(MessageBody request)
        {
            var connection = await _rabbitConfiguration.GetConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            var exchangeName = $"{request.QueueName}.exchange";

            await channel.ExchangeDeclareAsync(
                exchange: exchangeName,
                type: ExchangeType.Direct,
                durable: true);

            var json = JsonSerializer.Serialize(request.Body);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties
            {
                Persistent = true,
                ContentType = "application/json"
            };

            await channel.BasicPublishAsync(
                exchange: exchangeName,
                routingKey: request.QueueName,
                basicProperties: properties,
                body: body,
                mandatory: true
            );
        }
    }
}
