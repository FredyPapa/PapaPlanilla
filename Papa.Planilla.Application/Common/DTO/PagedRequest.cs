using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Common.DTO
{
    public class PagedRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
