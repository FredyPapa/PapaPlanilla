using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.ValueObjects
{
    public class CodigoPresupuestal
    {
        public string Codigo { get; init; }
        public string Descripcion { get; init; }

        private CodigoPresupuestal() { }

        private CodigoPresupuestal(string codigo, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código presupuestal no puede estar vacío.", nameof(codigo));
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del código presupuestal no puede estar vacía.", nameof(descripcion));
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public static CodigoPresupuestal Crear(string codigo, string descripcion)
        {
            return new CodigoPresupuestal(codigo, descripcion);
        }
    }
}
