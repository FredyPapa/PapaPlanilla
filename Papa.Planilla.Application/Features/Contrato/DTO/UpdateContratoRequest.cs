using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.DTO
{
    public class UpdateContratoRequest
    {
        public Guid Id { get; set; }
        public Guid TrabajadorId { get; set; }
        public Guid UnidadOrganicaId { get; set; }
        public Guid CargoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string SueldoMoneda { get; set; } = default!;
        public decimal SueldoMonto { get; set; }
        public string EstadoContrato { get; set; } = default!;
    }
}
