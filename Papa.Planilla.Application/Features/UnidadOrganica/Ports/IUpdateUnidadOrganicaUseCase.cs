using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.Ports
{
    public interface IUpdateUnidadOrganicaUseCase
    {
        Task<Result> ExecuteAsync(UpdateUnidadOrganicaRequest request);
    }
}
