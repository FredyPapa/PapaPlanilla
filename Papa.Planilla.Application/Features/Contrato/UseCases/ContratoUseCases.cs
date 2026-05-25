using Papa.Planilla.Application.Features.Contrato.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public record ContratoUseCases
    (
        ICreateContratoUseCase create,
        IListContratoUseCase list
    );
}
