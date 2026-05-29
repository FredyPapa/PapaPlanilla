using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.Ports
{
    public interface IUpdateContratoUseCase
    {
        Task<Result> ExecuteAsync(UpdateContratoRequest request);
    }
}
