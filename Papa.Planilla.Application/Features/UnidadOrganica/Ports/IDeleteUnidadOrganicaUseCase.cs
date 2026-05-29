using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.Ports
{
    public interface IDeleteUnidadOrganicaUseCase
    {
        Task<Result> ExecuteAsync(Guid id);
    }
}
