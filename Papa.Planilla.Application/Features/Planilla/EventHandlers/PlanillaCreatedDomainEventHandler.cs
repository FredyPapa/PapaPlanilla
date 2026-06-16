using Papa.Planilla.Domain.Events.Domain;
using Papa.Planilla.Domain.Events.Integration;
using Papa.Planilla.Domain.Model.Messages;
using Papa.Planilla.Domain.Ports.Messages;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.EventHandlers
{
    public class PlanillaCreatedDomainEventHandler : IDomainEventHandler<PlanillaCreatedDomainEvent>
    {
        private readonly IRabbitProducerService _rabbitProducerService;

        public PlanillaCreatedDomainEventHandler(IRabbitProducerService rabbitProducerService)
        {
            _rabbitProducerService = rabbitProducerService;
        }
        public async Task HandlerAsync(PlanillaCreatedDomainEvent domainEvent)
        {
            var planilla = new PlanillaCreatedIntegrationEvent(
                domainEvent.PlanillaId,
                domainEvent.TrabajadorId,
                domainEvent.ContratoId,
                domainEvent.Anio,
                domainEvent.Mes,
                domainEvent.SueldoBasicoMoneda,
                domainEvent.SueldoBasicoMonto,
                domainEvent.TotalIngresosMoneda,
                domainEvent.TotalIngresosMonto,
                domainEvent.TotalDescuentosMoneda,
                domainEvent.TotalDescuentosMonto
            );

            await _rabbitProducerService.PublishAsync(new MessageBody
            {
                QueueName = "generate-calculo-bonos-adicionales",
                Body = planilla
            });
        }
    }
}
