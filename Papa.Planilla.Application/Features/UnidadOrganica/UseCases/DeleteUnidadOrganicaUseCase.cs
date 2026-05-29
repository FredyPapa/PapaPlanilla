using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public class DeleteUnidadOrganicaUseCase : IDeleteUnidadOrganicaUseCase
    {
        private readonly IUnidadOrganicaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnidadOrganicaUseCase(IUnidadOrganicaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(Guid id)
        {
            var uo = await _repository.GetByIdAsync(id);
            if (uo == null || !uo.Estado)
            {
                return Result.Failure("La unidad orgánica no existe.");
            }

            uo.Eliminar();

            _repository.Update(uo);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Unidad orgánica eliminada exitosamente.");
        }
    }
}
