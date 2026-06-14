using Papa.Planilla.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class EntidadBase
    {
        public Guid Id { get; protected set; }
        public bool Estado { get; protected set; }
        public DateTime FechaCreacion { get; protected set; }
        public int UsuarioCreacion { get; protected set; }
        public DateTime? FechaActualizacion { get; protected set; }
        public int UsuarioActualizacion { get; protected set; }

        //Para eventos de dominio que permitan encolar el mensaje
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
        //

        protected EntidadBase()
        {
            Id = Guid.NewGuid();
            Estado = true;
            FechaCreacion = DateTime.UtcNow;
            UsuarioCreacion = 1;
        }

        public void Eliminar()
        {
            Estado = false;
            FechaActualizacion = DateTime.UtcNow;
            UsuarioActualizacion= 1;
        }

        //Agregamos el evento mediante el patrón Factory
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
