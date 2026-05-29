using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.Ports
{
    public interface IDeleteCargoUseCase
    {
        Task<Result> ExecuteAsync(Guid id);
    }
}
