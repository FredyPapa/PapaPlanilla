using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Entities;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnidadOrganicaEntity = Papa.Planilla.Domain.Entities.UnidadOrganica;

namespace Papa.Planilla.Application.Features.UnidadOrganica.UseCases
{
    public class CreateUnidadOrganicaUseCase : ICreateUnidadOrganicaUseCase
    {
        private readonly IUnidadOrganicaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnidadOrganicaUseCase(IUnidadOrganicaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(CreateUnidadOrganicaRequest request)
        {
            //Validamos si existe el cargo
            var existingUnidadOrganica = await _repository.FindAysnc(p => p.Descripcion.ToUpper() == request.Descripcion.ToUpper());
            if (existingUnidadOrganica != null)
            {
                return Result.Failure("Existe una unidad orgánica con la misma descripción.");
            }

            //Creamos las instancias
            var codigoPresupuestal = CodigoPresupuestal.Crear(request.CodigoPresupuestal, request.CodigoPresupuestalDescripcion);
            var unidadOrganica = UnidadOrganicaEntity.Crear(request.Descripcion, codigoPresupuestal);
            //Enviamos al repositorio
            await _repository.AddAsync(unidadOrganica);
            //Guardamos los cambios
            await _unitOfWork.SaveChangesAsync();
            //Retornamos resultado (mensaje)
            return Result.Success("Undiad orgánica creada exitosamente.");
        }
    }
}
