using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using PlanillaEntity = Papa.Planilla.Domain.Entities.Planilla;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public class CreatePlanillaUseCase : ICreatePlanillaUseCase
    {
        private readonly IPlanillaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly IContratoRepository _contratoRepository;

        public CreatePlanillaUseCase(IPlanillaRepository repository, IUnitOfWork unitOfWork, ITrabajadorRepository trabajadorRepository, IContratoRepository contratoRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _trabajadorRepository = trabajadorRepository;
            _contratoRepository = contratoRepository;
        }

        public async Task<Result> ExecuteAsync(CreatePlanillaRequest request)
        {
            // Recuperar las entidades referenciadas por Id
            var trabajador = await _trabajadorRepository.GetByIdAsync(request.TrabajadorId);
            if (trabajador == null)
                return Result.Failure("Trabajador no encontrado.");

            var contrato = await _contratoRepository.GetByIdAsync(request.ContratoId);
            if (contrato == null)
                return Result.Failure("Contrato no encontrado.");

            //Creamos las instancias
            var sueldoBasico = Importe.Crear(request.SueldoBasicoMoneda, request.SueldoBasicoMonto);
            var totalIngresos = Importe.Crear(request.TotalIngresosMoneda, request.TotalIngresosMonto);
            var totalDescuentos = Importe.Crear(request.TotalDescuentosMoneda, request.TotalDescuentosMonto);
            var planilla = PlanillaEntity.Crear(request.Anio, request.Mes, trabajador, contrato, sueldoBasico, totalIngresos, totalDescuentos);
            //Enviamos al repositorio
            await _repository.AddAsync(planilla);
            //Guardamos los cambios
            await _unitOfWork.SaveChangesAsync();
            //Retornamos resultado (mensaje)
            return Result.Success("Planilla creada exitosamente.");
        }
    }
}
