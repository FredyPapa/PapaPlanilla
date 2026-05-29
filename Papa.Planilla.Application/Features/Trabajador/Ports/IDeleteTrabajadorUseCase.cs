using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.Ports
{
    public interface IDeleteTrabajadorUseCase
    {
        Task<Result> ExecuteAsync(Guid id);
    }
}
