using Papa.Planilla.Application.Features.Planilla.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Planilla.UseCases
{
    public class DeletePlanillaUseCase : IDeletePlanillaUseCase
    {
        private readonly IPlanillaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlanillaUseCase(IPlanillaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(Guid id)
        {
            var planilla = await _repository.GetByIdAsync(id);
            if (planilla == null || !planilla.Estado)
            {
                return Result.Failure("La planilla no existe.");
            }

            planilla.Eliminar();

            _repository.Update(planilla);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Planilla eliminada exitosamente.");
        }
    }
}
