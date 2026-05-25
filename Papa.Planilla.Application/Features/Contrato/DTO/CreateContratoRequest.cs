using Papa.Planilla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.DTO
{
    public class CreateContratoRequest
    {
        public Guid TrabajadorId { get; set; }
        public Guid UnidadOrganicaId { get; set; }
        public Guid CargoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string SueldoMoneda { get; init; } = null!;
        public decimal SueldoMonto { get; init; }
        public string EstadoContrato { get; set; } = null!;
    }
}
