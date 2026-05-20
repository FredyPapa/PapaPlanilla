using Papa.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PlanillaEntity = Papa.Planilla.Domain.Entities.Planilla;

namespace Papa.Planilla.Domain.Ports.Repositories
{
    public interface IPlanillaRepository : IBaseRepository<PlanillaEntity>
    {
    }
}
