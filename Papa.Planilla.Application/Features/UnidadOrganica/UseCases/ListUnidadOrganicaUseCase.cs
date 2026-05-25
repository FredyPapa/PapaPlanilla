using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public class ListUnidadOrganicaUseCase : IListUnidadOrganicaUseCase
    {
        private readonly IUnidadOrganicaRepository _repository;

        public ListUnidadOrganicaUseCase(IUnidadOrganicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ListUnidadOrganicaResponse>>> ExecuteAsync(ListUnidadOrganicaRequest request)
        {
            var result = await _repository.ListAsync
                (
                    predicate: p =>
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Descripcion.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.CodigoPresupuestal.Descripcion.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.CodigoPresupuestal.Codigo.Contains(request.Filter)),
                    selector: p => new ListUnidadOrganicaResponse
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        CodigoPresupuestal = p.CodigoPresupuestal.Codigo,
                        CodigoPresupuestalDescripcion = p.CodigoPresupuestal.Descripcion,
                        FechaCreacion = p.FechaCreacion
                    },
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize
                );
            return Result<List<ListUnidadOrganicaResponse>>.Success(result.Result.ToList());
        }
    }
}
