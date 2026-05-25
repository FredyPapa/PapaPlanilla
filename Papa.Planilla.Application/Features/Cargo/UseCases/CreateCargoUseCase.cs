using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;
using CargoEntity = Papa.Planilla.Domain.Entities.Cargo;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public class CreateCargoUseCase : ICreateCargoUseCase
    {
        private readonly ICargoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCargoUseCase(ICargoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(CreateCargoRequest request)
        {
            //Validamos si existe el cargo
            var existingCargo = await _repository.FindAysnc(p => p.Descripcion.ToUpper() == request.Descripcion.ToUpper());
            if (existingCargo != null)
            {
                return Result.Failure("Existe un cargo con la misma descripción.");
            }

            //Creamos las instancias
            var cargo = CargoEntity.Crear(request.Descripcion);
            //Enviamos al repositorio
            await _repository.AddAsync(cargo);
            //Guardamos los cambios
            await _unitOfWork.SaveChangesAsync();
            //Retornamos resultado (mensaje)
            return Result.Success("Cargo creado exitosamente.");
        }
    }
}
