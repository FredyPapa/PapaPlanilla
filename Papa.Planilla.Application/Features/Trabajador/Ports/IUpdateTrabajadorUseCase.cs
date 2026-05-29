using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.Ports
{
    public interface IUpdateTrabajadorUseCase
    {
        Task<Result> ExecuteAsync(UpdateTrabajadorRequest request);
    }
}
