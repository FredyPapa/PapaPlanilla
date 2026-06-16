using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Adapters.Services
{
    public class DomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchEventAsync(DbContext context)
        {
            //Obtenemos las entidades
            var entities = context.ChangeTracker
                .Entries<Domain.Entities.EntidadBase>()
                .Where(e => e.Entity.DomainEvents.Any())
                .ToList();

            //Obtenemos los eventos de las entidades
            var events = entities
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            //Limpiamos las entidades
            entities.ForEach(e => e.Entity.RemoveDomainEvent());

            //Recorremos los eventos de dominio
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    var method = handlerType.GetMethod("HandlerAsync");
                    await (Task)method!.Invoke(handler, new object[] { domainEvent })!;
                }

            }
        }
    }
}
