using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Entities
{
    public class UnidadOrganica : EntidadBase
    {
        public string Descripcion { get; private set; } = null!;
        public CodigoPresupuestal CodigoPresupuestal { get; private set; } = null!;

        //Propiedades de Navegación
        private readonly List<Contrato> _contratos = new();
        public IReadOnlyCollection<Contrato> Contratos => _contratos.AsReadOnly();

        //Constructores
        private UnidadOrganica() { }

        private UnidadOrganica(string descripcion, CodigoPresupuestal codigoPresupuestal)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción de la unidad orgánica no puede estar vacía.", nameof(descripcion));
            if (codigoPresupuestal is null)
                throw new ArgumentException("El código presupuestal no puede estar vacío.", nameof(codigoPresupuestal));
            Descripcion = descripcion;
            CodigoPresupuestal = codigoPresupuestal;
        }

        //Patrón Factory
        public static UnidadOrganica Crear(string descripcion, CodigoPresupuestal codigoPresupuestal)
        {
            return new UnidadOrganica(descripcion, codigoPresupuestal);
        }

        //Actualizar
        public void Actualizar(string descripcion, CodigoPresupuestal codigoPresupuestal)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción de la unidad orgánica no puede estar vacía.", nameof(descripcion));
            if (codigoPresupuestal is null)
                throw new ArgumentException("El código presupuestal no puede estar vacío.", nameof(codigoPresupuestal));
            Descripcion = descripcion;
            CodigoPresupuestal = codigoPresupuestal;
            FechaActualizacion = DateTime.UtcNow;
            UsuarioActualizacion = 1;
        }
    }
}
