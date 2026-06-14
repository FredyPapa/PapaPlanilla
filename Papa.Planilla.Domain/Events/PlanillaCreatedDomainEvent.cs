using Papa.Planilla.Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Domain.Events
{
    public class PlanillaCreatedDomainEvent : IDomainEvent
    {
        public Guid PlanillaId { get;}
        public Guid TrabajadorId { get;}
        public Guid ContratoId { get;}
        public int Anio { get;}
        public int Mes { get; }
        public string SueldoBasicoMoneda { get;}
        public decimal SueldoBasicoMonto { get;}
        public string TotalIngresosMoneda { get;}
        public decimal TotalIngresosMonto { get;}
        public string TotalDescuentosMoneda { get;}
        public decimal TotalDescuentosMonto { get;}

        public Guid Id => Guid.NewGuid();
        public DateTime OcurredOn => DateTime.UtcNow;

        public PlanillaCreatedDomainEvent(Guid planillaId, Guid trabajadorId, Guid contratoId, int anio, int mes, string sueldoBasicoMoneda, decimal sSueldoBasicoMonto, string totalIngresosMoneda, decimal totalIngresosMonto, string totalDescuentosMoneda, decimal totalDescuentosMonto)
        {
            PlanillaId = planillaId;
            TrabajadorId = trabajadorId;
            ContratoId = contratoId;
            Anio = anio;
            Mes = mes;
            SueldoBasicoMoneda = sueldoBasicoMoneda;
            SueldoBasicoMonto = SueldoBasicoMonto;
            TotalIngresosMoneda = totalIngresosMoneda;
            TotalIngresosMonto = totalDescuentosMonto;
            TotalDescuentosMoneda = totalDescuentosMoneda;
            TotalDescuentosMonto = totalDescuentosMonto;
        }
    }
}
