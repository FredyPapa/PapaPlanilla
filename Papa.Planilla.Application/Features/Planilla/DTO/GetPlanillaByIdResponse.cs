using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.DTO
{
    public class GetPlanillaByIdResponse
    {
        public Guid Id { get; set; }
        public int Anio { get; set; }
        public string Mes { get; set; } = default!;
        public Guid TrabajadorId { get; set; }
        public Guid ContratoId { get; set; }
        public string SueldoBasicoMoneda { get; set; } = default!;
        public decimal SueldoBasicoMonto { get; set; }
        public string TotalIngresosMoneda { get; set; } = default!;
        public decimal TotalIngresosMonto { get; set; }
        public string TotalDescuentosMoneda { get; set; } = default!;
        public decimal TotalDescuentosMonto { get; set; }
        public decimal SueldoNeto { get; set; }
        public string EstadoPlanilla { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
