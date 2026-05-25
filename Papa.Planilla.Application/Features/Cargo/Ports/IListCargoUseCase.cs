using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.Ports
{
    public interface IListCargoUseCase
    {
        Task<Result<List<ListCargoResponse>>> ExecuteAsync(ListCargoRequest request);
    }
}
