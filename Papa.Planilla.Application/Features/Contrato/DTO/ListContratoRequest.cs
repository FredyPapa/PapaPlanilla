using Papa.Planilla.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.DTO
{
    public class ListContratoRequest : PagedRequest
    {
        public string Filter { get; set; } = string.Empty;
    }
}
