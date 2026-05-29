using Papa.Planilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.DTO
{
    public class UpdatePlanillaRequest
    {
        public Guid Id { get; set; }
        public int Anio { get; set; }
        public Meses Mes { get; set; }
        public Guid TrabajadorId { get; set; }
        public Guid ContratoId { get; set; }
        public string SueldoBasicoMoneda { get; set; } = default!;
        public decimal SueldoBasicoMonto { get; set; }
        public string TotalIngresosMoneda { get; set; } = default!;
        public decimal TotalIngresosMonto { get; set; }
        public string TotalDescuentosMoneda { get; set; } = default!;
        public decimal TotalDescuentosMonto { get; set; }
        public string EstadoPlanilla { get; set; } = default!;
    }
}
