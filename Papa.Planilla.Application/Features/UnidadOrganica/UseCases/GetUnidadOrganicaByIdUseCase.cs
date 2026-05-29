using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public class GetUnidadOrganicaByIdUseCase : IGetUnidadOrganicaByIdUseCase
    {
        private readonly IUnidadOrganicaRepository _repository;

        public GetUnidadOrganicaByIdUseCase(IUnidadOrganicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetUnidadOrganicaByIdResponse>> ExecuteAsync(Guid id)
        {
            var uo = await _repository.GetByIdAsync(id);
            if (uo == null || !uo.Estado)
            {
                return Result<GetUnidadOrganicaByIdResponse>.Failure("La unidad orgánica no existe.");
            }

            var response = new GetUnidadOrganicaByIdResponse
            {
                Id = uo.Id,
                Descripcion = uo.Descripcion,
                CodigoPresupuestal = uo.CodigoPresupuestal.Codigo,
                FechaCreacion = uo.FechaCreacion
            };

            return Result<GetUnidadOrganicaByIdResponse>.Success(response);
        }
    }
}
