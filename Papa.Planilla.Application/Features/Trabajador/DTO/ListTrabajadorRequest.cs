using Papa.Planilla.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.DTO
{
    public class ListTrabajadorRequest : PagedRequest
    {
        public string Filter { get; set; } = string.Empty;
    }
}
