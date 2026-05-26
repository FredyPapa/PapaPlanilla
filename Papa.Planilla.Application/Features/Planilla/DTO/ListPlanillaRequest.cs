using Papa.Planilla.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.DTO
{
    public class ListPlanillaRequest : PagedRequest
    {
        public string Filter { get; set; } = string.Empty;
    }
}
