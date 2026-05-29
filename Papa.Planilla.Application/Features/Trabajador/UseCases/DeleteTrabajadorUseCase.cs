using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public class DeleteTrabajadorUseCase : IDeleteTrabajadorUseCase
    {
        private readonly ITrabajadorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTrabajadorUseCase(ITrabajadorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(Guid id)
        {
            var trabajador = await _repository.GetByIdAsync(id);
            if (trabajador == null || !trabajador.Estado)
            {
                return Result.Failure("El trabajador no existe.");
            }

            trabajador.Eliminar();

            _repository.Update(trabajador);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Trabajador eliminado exitosamente.");
        }
    }
}
