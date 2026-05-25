using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Adapters.Repositories
{
    public class UnidadOrganicaRepository(PlanillaDbContext context) : BaseRepository<UnidadOrganica>(context), Domain.Ports.Repositories.IUnidadOrganicaRepository
    {
    }
}
