using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public class UpdateUnidadOrganicaUseCase : IUpdateUnidadOrganicaUseCase
    {
        private readonly IUnidadOrganicaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnidadOrganicaUseCase(IUnidadOrganicaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(UpdateUnidadOrganicaRequest request)
        {
            var uo = await _repository.GetByIdAsync(request.Id);
            if (uo == null || !uo.Estado)
            {
                return Result.Failure("La unidad orgánica no existe.");
            }

            // Validar descripción duplicada
            var existingUO = await _repository.FindAysnc(u => u.Descripcion == request.Descripcion && u.Id != request.Id);
            if (existingUO != null)
            {
                return Result.Failure("Existe otra unidad orgánica con la misma descripción.");
            }

            // Validar código presupuestal duplicado
            var existingCodigo = await _repository.FindAysnc(u => u.CodigoPresupuestal.Codigo == request.CodigoPresupuestal && u.Id != request.Id);
            if (existingCodigo != null)
            {
                return Result.Failure("Existe otra unidad orgánica con el mismo código presupuestal.");
            }

            var cp = CodigoPresupuestal.Crear(request.CodigoPresupuestal, request.CodigoPresupuestalDescripcion);
            uo.Actualizar(request.Descripcion, cp);

            _repository.Update(uo);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Unidad orgánica actualizada exitosamente.");
        }
    }
}
