using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Enums;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public class UpdatePlanillaUseCase : IUpdatePlanillaUseCase
    {
        private readonly IPlanillaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly IContratoRepository _contratoRepository;

        public UpdatePlanillaUseCase(IPlanillaRepository repository, IUnitOfWork unitOfWork, ITrabajadorRepository trabajadorRepository, IContratoRepository contratoRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _trabajadorRepository = trabajadorRepository;
            _contratoRepository = contratoRepository;
        }

        public async Task<Result> ExecuteAsync(UpdatePlanillaRequest request)
        {
            var planilla = await _repository.GetByIdAsync(request.Id);
            if (planilla == null || !planilla.Estado)
            {
                return Result.Failure("La planilla no existe.");
            }

            var trabajador = await _trabajadorRepository.GetByIdAsync(request.TrabajadorId);
            if (trabajador == null)
            {
                return Result.Failure("El trabajador no existe.");
            }

            var contrato = await _contratoRepository.GetByIdAsync(request.ContratoId);
            if (contrato == null)
            {
                return Result.Failure("El contrato no existe.");
            }

            if (!Enum.TryParse<PlanillaEstado>(request.EstadoPlanilla, true, out var estadoPlanilla))
            {
                return Result.Failure("El estado de planilla no es válido.");
            }

            var sueldoBasico = Importe.Crear(request.SueldoBasicoMoneda, request.SueldoBasicoMonto);
            var totalIngresos = Importe.Crear(request.TotalIngresosMoneda, request.TotalIngresosMonto);
            var totalDescuentos = Importe.Crear(request.TotalDescuentosMoneda, request.TotalDescuentosMonto);

            planilla.Actualizar(request.Anio, request.Mes, request.TrabajadorId, request.ContratoId, sueldoBasico, totalIngresos, totalDescuentos, estadoPlanilla);

            _repository.Update(planilla);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Planilla actualizada exitosamente.");
        }
    }
}
