using Papa.Planilla.Application.Features.Cargo.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public record CargoUseCases(
        ICreateCargoUseCase create,
        IListCargoUseCase list
    );
}
