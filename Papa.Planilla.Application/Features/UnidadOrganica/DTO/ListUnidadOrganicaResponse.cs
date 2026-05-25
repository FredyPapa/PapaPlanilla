using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.DTO
{
    public class ListUnidadOrganicaResponse
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public string CodigoPresupuestal { get; set; } = default!;
        public string CodigoPresupuestalDescripcion { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
