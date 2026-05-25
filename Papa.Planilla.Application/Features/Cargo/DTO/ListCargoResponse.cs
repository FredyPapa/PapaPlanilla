using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.DTO
{
    public class ListCargoResponse
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
