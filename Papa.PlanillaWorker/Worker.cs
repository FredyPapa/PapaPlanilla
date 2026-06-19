using Papa.Planilla.Domain.Events.Integration;
using Papa.Planilla.Domain.Ports.Messages;

namespace Papa.PlanillaWorker
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var consumer = scope.ServiceProvider.GetRequiredService<IRabbitConsumerService>();

            await consumer.SubscribeAsync<PlanillaCreatedIntegrationEvent>(
                "generate-calculo-bonos-adicionales",
                async(sp, message) =>
                {
                    Console.WriteLine($"Se recibió PlanillaCreatedIntegrationEvent para PlanillaId: {message.PlanillaId}");
                    Console.WriteLine("Se realizarán las acciones correspondientes");
                });

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
