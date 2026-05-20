using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Infraestructure.Adapters.Repositories
{
    public class ContratoRepository(PlanillaDbContext context) : BaseRepository<Contrato>(context), IContratoRepository
    {
    }
}
