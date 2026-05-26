using Papa.Planilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.DTO
{
    public class CreatePlanillaRequest
    {
        public int Anio { get; set; }
        public Meses Mes { get; set; }
        public Guid TrabajadorId { get; set; }
        public Guid ContratoId { get; set; }
        public string SueldoBasicoMoneda { get; init; } = null!;
        public decimal SueldoBasicoMonto { get; init; }
        public string TotalIngresosMoneda { get; init; } = null!;
        public decimal TotalIngresosMonto { get; init; }
        public string TotalDescuentosMoneda { get; init; } = null!;
        public decimal TotalDescuentosMonto { get; init; }
    }
}
