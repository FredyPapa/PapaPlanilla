using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.DTO
{
    public class CreateTrabajadorRequest
    {
        public string TipoDocumento { get; set; } = default!;
        public string NumeroDocumento { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string ApellidoMaterno { get; set; } = default!;
        public string Nombres { get; set; } = default!;
        public string? Correo { get; set; }
        public string CodigoPaisCelular { get; set; } = default!;
        public string NumeroCelular { get; set; } = default!;
    }
}
