using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Enums;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public class UpdateContratoUseCase : IUpdateContratoUseCase
    {
        private readonly IContratoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly IUnidadOrganicaRepository _unidadOrganicaRepository;
        private readonly ICargoRepository _cargoRepository;

        public UpdateContratoUseCase(IContratoRepository repository, IUnitOfWork unitOfWork, ITrabajadorRepository trabajadorRepository, IUnidadOrganicaRepository unidadOrganicaRepository, ICargoRepository cargoRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _trabajadorRepository = trabajadorRepository;
            _unidadOrganicaRepository = unidadOrganicaRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<Result> ExecuteAsync(UpdateContratoRequest request)
        {
            var contrato = await _repository.GetByIdAsync(request.Id);
            if (contrato == null || !contrato.Estado)
            {
                return Result.Failure("El contrato no existe.");
            }

            var trabajador = await _trabajadorRepository.GetByIdAsync(request.TrabajadorId);
            if (trabajador == null)
            {
                return Result.Failure("El trabajador no existe.");
            }

            var uo = await _unidadOrganicaRepository.GetByIdAsync(request.UnidadOrganicaId);
            if (uo == null)
            {
                return Result.Failure("La unidad orgánica no existe.");
            }

            var cargo = await _cargoRepository.GetByIdAsync(request.CargoId);
            if (cargo == null)
            {
                return Result.Failure("El cargo no existe.");
            }

            if (!Enum.TryParse<ContratoEstado>(request.EstadoContrato, true, out var estadoContrato))
            {
                return Result.Failure("El estado de contrato no es válido.");
            }

            var sueldo = Importe.Crear(request.SueldoMoneda, request.SueldoMonto);

            contrato.Actualizar(request.TrabajadorId, request.UnidadOrganicaId, request.CargoId, request.FechaInicio, request.FechaFin, sueldo, estadoContrato);

            _repository.Update(contrato);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Contrato actualizado exitosamente.");
        }
    }
}
