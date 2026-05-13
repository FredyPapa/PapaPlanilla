using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.ValueObjects
{
    public class NumeroCelular
    {
        public string? CodigoPais { get; init; }
        public string? Numero { get; init; }

        private NumeroCelular() { }

        private NumeroCelular(string codigoPais, string numero)
        {
            if (string.IsNullOrWhiteSpace(codigoPais))
                throw new ArgumentException("El código de país no puede estar vacío.", nameof(codigoPais));
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número de celular no puede estar vacío.", nameof(numero));

            CodigoPais = codigoPais;
            Numero = numero;
        }

        public static NumeroCelular Crear(string codigoPais, string numero)
        {
            return new NumeroCelular(codigoPais, numero);
        }
    }
}
