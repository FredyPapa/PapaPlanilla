using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;
using PlanillaEntity = Papa.Planilla.Domain.Entities.Planilla;

namespace Papa.Planilla.Infraestructure.Adapters.Repositories
{
    public class PlanillaRepository(PlanillaDbContext context) : BaseRepository<PlanillaEntity>(context), IPlanillaRepository
    {
    }
}
