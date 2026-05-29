using Papa.Planilla.Application.Features.Trabajador.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public record TrabajadorUseCases(
        ICreateTrabajadorUseCase create,
        IListTrabajadorUseCase list,
        IGetTrabajadorByIdUseCase getById
    );
}
