using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public class DeleteCargoUseCase : IDeleteCargoUseCase
    {
        private readonly ICargoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCargoUseCase(ICargoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> ExecuteAsync(Guid id)
        {
            var cargo = await _repository.GetByIdAsync(id);
            if (cargo == null || !cargo.Estado)
            {
                return Result.Failure("El cargo no existe.");
            }

            cargo.Eliminar();

            _repository.Update(cargo);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Cargo eliminado exitosamente.");
        }
    }
}
