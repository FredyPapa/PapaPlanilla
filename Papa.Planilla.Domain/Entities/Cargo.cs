using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class Cargo : EntidadBase
    {
        public string Descripcion { get; private set; } = null!;

        //Propiedades de Navegación
        private readonly List<Contrato> _contratos = new();
        public IReadOnlyCollection<Contrato> Contratos => _contratos.AsReadOnly();

        //Constructores
        private Cargo() { }

        private Cargo(string descripcion) {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del cargo no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        //Patrón Factory
        public static Cargo Crear(string descripcion)
        {
            return new Cargo(descripcion);
        }
    }
}
