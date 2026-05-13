using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Cargo : EntidadBase
    {
        public string Descripcion { get; private set; }

        private Cargo() { }

        private Cargo(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del cargo no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        public static Cargo Crear(string descripcion)
        {
            return new Cargo(descripcion);
        }
    }
}
