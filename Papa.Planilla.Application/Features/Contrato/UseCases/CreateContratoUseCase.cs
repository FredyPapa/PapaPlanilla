using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContratoEntity = Papa.Planilla.Domain.Entities.Contrato;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public class CreateContratoUseCase : ICreateContratoUseCase
    {
        private readonly IContratoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly IUnidadOrganicaRepository _unidadOrganicaRepository;
        private readonly ICargoRepository _cargoRepository;

        public CreateContratoUseCase(
            IContratoRepository repository,
            IUnitOfWork unitOfWork,
            ITrabajadorRepository trabajadorRepository,
            IUnidadOrganicaRepository unidadOrganicaRepository,
            ICargoRepository cargoRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _trabajadorRepository = trabajadorRepository;
            _unidadOrganicaRepository = unidadOrganicaRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<Result> ExecuteAsync(CreateContratoRequest request)
        {
            // Recuperar las entidades referenciadas por Id
            var trabajador = await _trabajadorRepository.GetByIdAsync(request.TrabajadorId);
            if (trabajador == null)
                return Result.Failure("Trabajador no encontrado.");

            var unidad = await _unidadOrganicaRepository.GetByIdAsync(request.UnidadOrganicaId);
            if (unidad == null)
                return Result.Failure("Unidad orgánica no encontrada.");

            var cargo = await _cargoRepository.GetByIdAsync(request.CargoId);
            if (cargo == null)
                return Result.Failure("Cargo no encontrado.");

            //Creamos las instancias
            var sueldo = Importe.Crear(request.SueldoMoneda, request.SueldoMonto);
            var contrato = ContratoEntity.Crear(trabajador, unidad, cargo, request.FechaInicio, request.FechaFin, sueldo);
            //Enviamos al repositorio
            await _repository.AddAsync(contrato);
            //Guardamos los cambios
            await _unitOfWork.SaveChangesAsync();
            //Retornamos resultado (mensaje)
            return Result.Success("Contrato creado exitosamente.");
        }
    }
}
