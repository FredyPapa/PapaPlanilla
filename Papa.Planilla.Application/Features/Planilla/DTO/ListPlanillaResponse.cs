using Papa.Planilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.DTO
{
    public class ListPlanillaResponse
    {
        public Guid Id { get; set; }
        public int Anio { get; set; }
        public Meses Mes { get; set; }
        public string Trabajador { get; set; } = default!;
        public string Contrato { get; set; } = default!;
        public string SueldoBasicoMoneda { get; init; } = null!;
        public decimal SueldoBasicoMonto { get; init; }
        public string TotalIngresosMoneda { get; init; } = null!;
        public decimal TotalIngresosMonto { get; init; }
        public string TotalDescuentosMoneda { get; init; } = null!;
        public decimal TotalDescuentosMonto { get; init; }
        public string EstadoPlanilla { get; init; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
