using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.ValueObjects
{
    public class DocumentoIdentidad
    {
        public string Tipo { get; init; } = null!;
        public string Numero { get; init; } = null!;

        private DocumentoIdentidad() { }

        private DocumentoIdentidad(string tipo, string numero)
        {
            if(string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo de documento no puede estar vacío.", nameof(tipo));
            
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El tipo de documento no puede estar vacío.", nameof(tipo));
            
            Tipo = tipo;
            Numero = numero;
        }

        public static DocumentoIdentidad Crear(string tipo, string numero)
        {
            return new DocumentoIdentidad(tipo, numero);
        }
    }
}
