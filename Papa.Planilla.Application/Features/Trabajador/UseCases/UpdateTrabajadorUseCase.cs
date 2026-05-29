using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public class UpdateTrabajadorUseCase : IUpdateTrabajadorUseCase
    {
        private readonly ITrabajadorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTrabajadorUseCase(ITrabajadorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(UpdateTrabajadorRequest request)
        {
            var trabajador = await _repository.GetByIdAsync(request.Id);
            if (trabajador == null || !trabajador.Estado)
            {
                return Result.Failure("El trabajador no existe.");
            }

            // Validación de existencia de otro trabajador con el mismo Documento de identidad
            var existingTrabajador = await _repository.FindAysnc(p =>
                p.DocumentoIdentidad.Tipo == request.TipoDocumento &&
                p.DocumentoIdentidad.Numero == request.NumeroDocumento &&
                p.Id != request.Id);

            if (existingTrabajador != null)
            {
                return Result.Failure("Existe otro trabajador con el mismo documento de identidad.");
            }

            // Validación de existencia de otro trabajador con el mismo Número de Celular
            var existingNumeroTrabajador = await _repository.FindAysnc(p =>
                p.NumeroCelular.CodigoPais == request.CodigoPaisCelular &&
                p.NumeroCelular.Numero == request.NumeroCelular &&
                p.Id != request.Id);

            if (existingNumeroTrabajador != null)
            {
                return Result.Failure("Existe otro trabajador con el mismo número de celular.");
            }

            // Validación de existencia de otro trabajador con el mismo Correo
            var existingCorreoTrabajador = await _repository.FindAysnc(p =>
                p.Correo == request.Correo &&
                p.Id != request.Id);

            if (existingCorreoTrabajador != null)
            {
                return Result.Failure("Existe otro trabajador con el mismo correo.");
            }

            var di = DocumentoIdentidad.Crear(request.TipoDocumento, request.NumeroDocumento);
            var nc = NumeroCelular.Crear(request.CodigoPaisCelular, request.NumeroCelular);

            trabajador.Actualizar(di, request.ApellidoPaterno, request.ApellidoMaterno, request.Nombres, request.Correo, nc);

            _repository.Update(trabajador);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Trabajador actualizado exitosamente.");
        }
    }
}
