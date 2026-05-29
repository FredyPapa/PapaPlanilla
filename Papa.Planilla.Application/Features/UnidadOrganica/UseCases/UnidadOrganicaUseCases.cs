using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public record UnidadOrganicaUseCases(
        ICreateUnidadOrganicaUseCase create,
        IListUnidadOrganicaUseCase list,
        IGetUnidadOrganicaByIdUseCase getById,
        IUpdateUnidadOrganicaUseCase update,
        IDeleteUnidadOrganicaUseCase delete
    );
}
