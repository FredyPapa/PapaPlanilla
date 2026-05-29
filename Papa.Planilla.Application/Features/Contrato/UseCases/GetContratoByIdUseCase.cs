using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public class GetContratoByIdUseCase : IGetContratoByIdUseCase
    {
        private readonly IContratoRepository _repository;

        public GetContratoByIdUseCase(IContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetContratoByIdResponse>> ExecuteAsync(Guid id)
        {
            var contrato = await _repository.GetByIdAsync(id);
            if (contrato == null)
            {
                return Result<GetContratoByIdResponse>.Failure("El contrato no existe.");
            }

            var response = new GetContratoByIdResponse
            {
                Id = contrato.Id,
                TrabajadorId = contrato.TrabajadorId,
                UnidadOrganicaId = contrato.UnidadOrganicaId,
                CargoId = contrato.CargoId,
                FechaInicio = contrato.FechaInicio,
                FechaFin = contrato.FechaFin,
                SueldoMoneda = contrato.Sueldo.Moneda,
                SueldoMonto = contrato.Sueldo.Monto,
                EstadoContrato = contrato.EstadoContrato.ToString(),
                FechaCreacion = contrato.FechaCreacion
            };

            return Result<GetContratoByIdResponse>.Success(response);
        }
    }
}
