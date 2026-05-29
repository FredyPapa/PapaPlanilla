using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public class ListTrabajadorByIdUseCase : IGetTrabajadorByIdUseCase
    {
        private readonly ITrabajadorRepository _repository;

        public ListTrabajadorByIdUseCase(ITrabajadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetTrabajadorByIdResponse>> ExecuteAsync(Guid id)
        {
            var trabajador = await _repository.GetByIdAsync(id);
            if (trabajador == null || !trabajador.Estado)
            {
                return Result<GetTrabajadorByIdResponse>.Failure("El trabajador no existe.");
            }

            var response = new GetTrabajadorByIdResponse
            {
                Id = trabajador.Id,
                TipoDocumento = trabajador.DocumentoIdentidad.Tipo,
                NumeroDocumento = trabajador.DocumentoIdentidad.Numero,
                ApellidoPaterno = trabajador.ApellidoPaterno,
                ApellidoMaterno = trabajador.ApellidoMaterno,
                Nombres = trabajador.Nombres,
                Correo = trabajador.Correo,
                CodigoPaisCelular = trabajador.NumeroCelular.CodigoPais,
                NumeroCelular = trabajador.NumeroCelular.Numero,
                FechaCreacion = trabajador.FechaCreacion
            };

            return Result<GetTrabajadorByIdResponse>.Success(response);
        }
    }
}
