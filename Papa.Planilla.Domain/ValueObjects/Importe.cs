using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.ValueObjects
{
    public class Importe
    {
        public string Moneda { get; init; } = null!;
        public decimal Monto { get; init; }

        private Importe() { }

        private Importe(string moneda, decimal monto)
        {
            if (string.IsNullOrWhiteSpace(moneda))
                throw new ArgumentException("La moneda no puede estar vacía.", nameof(moneda));
            if (monto <= 0)
                throw new ArgumentException("El monto no puede menor o igual a cero.", nameof(monto));
            Moneda = moneda;
            Monto = monto;
        }

        public static Importe Crear(string moneda, decimal monto)
        {
            return new Importe(moneda, monto);
        }

        public static Importe operator +(Importe a, Importe b)
        {
            if (a.Moneda != b.Moneda)
                throw new InvalidOperationException("No se pueden sumar importes de diferentes monedas.");
            return new Importe(a.Moneda, a.Monto + b.Monto);
        }

        public static Importe operator -(Importe a, Importe b)
        {
            if (a.Moneda != b.Moneda)
                throw new InvalidOperationException("No se pueden restar importes de diferentes monedas.");
            return new Importe(a.Moneda, a.Monto - b.Monto);
        }
    }
}
