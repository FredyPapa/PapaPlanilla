using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.Ports
{
    public interface IListPlanillaUseCase
    {
        Task<Result<List<ListPlanillaResponse>>> ExecuteAsync(ListPlanillaRequest request);
    }
}
