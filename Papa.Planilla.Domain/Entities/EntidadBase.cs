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

        protected EntidadBase()
        {
            Id = Guid.NewGuid();
            Estado = true;
            FechaCreacion = DateTime.UtcNow;
            UsuarioCreacion = 1;
        }

        protected void Eliminar()
        {
            Estado = false;
            FechaActualizacion = DateTime.UtcNow;
            UsuarioActualizacion= 1;
        }
    }
}
