using Papa.Planilla.Application.Features.Planilla.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public record PlanillaUseCases(
        ICreatePlanillaUseCase create,
        IListPlanillaUseCase list
    );
}
