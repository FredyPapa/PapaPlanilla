using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public class UpdateCargoUseCase : IUpdateCargoUseCase
    {
        private readonly ICargoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCargoUseCase(ICargoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(UpdateCargoRequest request)
        {
            var cargo = await _repository.GetByIdAsync(request.Id);
            if (cargo == null || !cargo.Estado)
            {
                return Result.Failure("El cargo no existe.");
            }

            // Validar que no exista otro cargo con la misma descripción
            var existingCargo = await _repository.FindAysnc(c => c.Descripcion == request.Descripcion && c.Id != request.Id);
            if (existingCargo != null)
            {
                return Result.Failure("Existe otro cargo con la misma descripción.");
            }

            cargo.Actualizar(request.Descripcion);

            _repository.Update(cargo);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Cargo actualizado exitosamente.");
        }
    }
}
