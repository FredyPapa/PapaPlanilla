using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.DTO
{
    public class ListContratoResponse
    {
        public Guid Id { get; set; }
        public string Trabajador { get; set; } = default!;
        public string UndiadOrganica { get; set; } = default!;
        public string Cargo { get; set; } = default!;
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string SueldoMoneda { get; init; } = default!;
        public decimal SueldoMonto { get; init; }
        public string EstadoContrato { get; init; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
