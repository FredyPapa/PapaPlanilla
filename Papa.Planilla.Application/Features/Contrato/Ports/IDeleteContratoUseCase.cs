using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.Ports
{
    public interface IDeleteContratoUseCase
    {
        Task<Result> ExecuteAsync(Guid id);
    }
}
