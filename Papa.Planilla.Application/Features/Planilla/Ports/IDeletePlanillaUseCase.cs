using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.Ports
{
    public interface IDeletePlanillaUseCase
    {
        Task<Result> ExecuteAsync(Guid id);
    }
}
