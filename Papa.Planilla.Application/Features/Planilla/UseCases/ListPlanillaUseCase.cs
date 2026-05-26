using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public class ListPlanillaUseCase : IListPlanillaUseCase
    {
        private readonly IPlanillaRepository _repository;

        public ListPlanillaUseCase(IPlanillaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ListPlanillaResponse>>> ExecuteAsync(ListPlanillaRequest request)
        {
            var result = await _repository.ListAsync
                (
                    predicate: p =>
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Anio.ToString().Contains(request.Filter)) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Mes.ToString().Contains(request.Filter)) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.Nombres.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.ApellidoPaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Trabajador.ApellidoMaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.EstadoPlanilla.ToString().Contains(request.Filter)),
                    selector: p => new ListPlanillaResponse
                    {
                        Id = p.Id,
                        Anio = p.Anio,
                        Mes = p.Mes,
                        Trabajador = p.Trabajador.Nombres + " " + p.Trabajador.ApellidoPaterno + " " + p.Trabajador.ApellidoMaterno,
                        Contrato = p.Contrato.Id.ToString(),
                        SueldoBasicoMoneda = p.SueldoBasico.Moneda,
                        SueldoBasicoMonto = p.SueldoBasico.Monto,
                        TotalIngresosMoneda = p.TotalIngresos.Moneda,
                        TotalIngresosMonto = p.TotalIngresos.Monto,
                        TotalDescuentosMoneda = p.TotalDescuentos.Moneda,
                        TotalDescuentosMonto = p.TotalDescuentos.Monto,
                        EstadoPlanilla = p.EstadoPlanilla.ToString(),
                        FechaCreacion = p.FechaCreacion,
                    },
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize
                );
            return Result<List<ListPlanillaResponse>>.Success(result.Result.ToList());
        }
    }
}
