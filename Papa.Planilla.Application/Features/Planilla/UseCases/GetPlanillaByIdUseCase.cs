using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public class GetPlanillaByIdUseCase : IGetPlanillaByIdUseCase
    {
        private readonly IPlanillaRepository _repository;

        public GetPlanillaByIdUseCase(IPlanillaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetPlanillaByIdResponse>> ExecuteAsync(Guid id)
        {
            var planilla = await _repository.GetByIdAsync(id);
            if (planilla == null || !planilla.Estado)
            {
                return Result<GetPlanillaByIdResponse>.Failure("La planilla no existe.");
            }

            var response = new GetPlanillaByIdResponse
            {
                Id = planilla.Id,
                Anio = planilla.Anio,
                Mes = planilla.Mes.ToString(),
                TrabajadorId = planilla.TrabajadorId,
                ContratoId = planilla.ContratoId,
                SueldoBasicoMoneda = planilla.SueldoBasico.Moneda,
                SueldoBasicoMonto = planilla.SueldoBasico.Monto,
                TotalIngresosMoneda = planilla.TotalIngresos.Moneda,
                TotalIngresosMonto = planilla.TotalIngresos.Monto,
                TotalDescuentosMoneda = planilla.TotalDescuentos.Moneda,
                TotalDescuentosMonto = planilla.TotalDescuentos.Monto,
                SueldoNeto = planilla.SueldoNeto.Monto,
                EstadoPlanilla = planilla.EstadoPlanilla.ToString(),
                FechaCreacion = planilla.FechaCreacion
            };

            return Result<GetPlanillaByIdResponse>.Success(response);
        }
    }
}
