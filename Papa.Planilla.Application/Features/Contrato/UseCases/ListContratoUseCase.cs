using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public class ListContratoUseCase : IListContratoUseCase
    {
        private readonly IContratoRepository _repository;

        public ListContratoUseCase(IContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ListContratoResponse>>> ExecuteAsync(ListContratoRequest request)
        {
            var result = await _repository.ListAsync
                (
                    predicate: p => p.Estado && (
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.Nombres.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.ApellidoPaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.ApellidoMaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.UnidadOrganica.Descripcion.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Cargo.Descripcion.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.FechaInicio.ToString().Contains(request.Filter))),
                    selector: p => new ListContratoResponse
                    {
                        Id = p.Id,
                        Trabajador = p.Trabajador.Nombres + " " + p.Trabajador.ApellidoPaterno + " " + p.Trabajador.ApellidoMaterno,
                        UndiadOrganica = p.UnidadOrganica.Descripcion,
                        Cargo = p.Cargo.Descripcion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        SueldoMoneda = p.Sueldo.Moneda,
                        SueldoMonto = p.Sueldo.Monto,
                        EstadoContrato = p.EstadoContrato.ToString(),
                        FechaCreacion = p.FechaCreacion,
                    },
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize
                );
            return Result<List<ListContratoResponse>>.Success(result.Result.ToList());
        }
    }
}
