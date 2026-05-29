using Papa.Planilla.Application.Features.Contrato.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Contrato.UseCases
{
    public class DeleteContratoUseCase : IDeleteContratoUseCase
    {
        private readonly IContratoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContratoUseCase(IContratoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(Guid id)
        {
            var contrato = await _repository.GetByIdAsync(id);
            if (contrato == null || !contrato.Estado)
            {
                return Result.Failure("El contrato no existe.");
            }

            contrato.Eliminar();

            _repository.Update(contrato);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Contrato eliminado exitosamente.");
        }
    }
}
