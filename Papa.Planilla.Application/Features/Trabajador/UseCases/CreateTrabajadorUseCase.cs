using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using Papa.Planilla.Domain.Ports.Services;
using Papa.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TrabajadorEntity = Papa.Planilla.Domain.Entities.Trabajador;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public class CreateTrabajadorUseCase : ICreateTrabajadorUseCase
    {
        private readonly ITrabajadorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTrabajadorUseCase(ITrabajadorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ExecuteAsync(CreateTrabajadorRequest request)
        {
            //Validación de existencia de cliente con el mismo Documento de identidad
            var existingTrabajador = await _repository.FindAysnc(p => p.DocumentoIdentidad.Tipo == request.TipoDocumento && p.DocumentoIdentidad.Numero == request.NumeroDocumento);
            if (existingTrabajador != null)
            {
                return Result.Failure("Existe un trabajador con el mismo documento de identidad.");
            }

            //Validación de existencia de cliente con el mismo Número de Celular
            var existingNumeroTrabajador = await _repository.FindAysnc(p => p.NumeroCelular.CodigoPais == request.CodigoPaisCelular && p.NumeroCelular.Numero == request.NumeroCelular);
            if (existingNumeroTrabajador != null)
            {
                return Result.Failure("Existe un trabajador con el mismo número de celular.");
            }

            //Validación de existencia de cliente con el mismo Correo
            var existingCorreoTrabajador = await _repository.FindAysnc(p => p.Correo == request.Correo);
            if (existingCorreoTrabajador != null)
            {
                return Result.Failure("Existe un trabajador con el mismo correo.");
            }

            //Creamos las instancias
            var documentoIdentidad = DocumentoIdentidad.Crear(request.TipoDocumento, request.NumeroDocumento);
            var numeroCelular = NumeroCelular.Crear(request.CodigoPaisCelular, request.NumeroCelular);
            var trabajador = TrabajadorEntity.Crear(documentoIdentidad, request.ApellidoPaterno, request.ApellidoMaterno, request.Nombres, request.Correo, numeroCelular);
            //Enviamos al repositorio
            await _repository.AddAsync(trabajador);
            //Guardamos los cambios
            await _unitOfWork.SaveChangesAsync();
            //Retornamos resultado (mensaje)
            return Result.Success("Trabajador creado exitosamente.");
        }
    }
}
