using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public class GetCargoByIdUseCase : IGetCargoByIdUseCase
    {
        private readonly ICargoRepository _repository;

        public GetCargoByIdUseCase(ICargoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<GetCargoByIdResponse>> ExecuteAsync(Guid id)
        {
            var cargo = await _repository.GetByIdAsync(id);
            if (cargo == null)
            {
                return Result<GetCargoByIdResponse>.Failure("El cargo no existe.");
            }

            var result = new GetCargoByIdResponse
            {
                Id = cargo.Id,
                Descripcion = cargo.Descripcion,
                FechaCreacion = cargo.FechaCreacion
            };

            return Result<GetCargoByIdResponse>.Success(result);
        }
    }
}
