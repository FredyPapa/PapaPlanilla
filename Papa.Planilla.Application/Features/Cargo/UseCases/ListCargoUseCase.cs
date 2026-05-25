using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.Cargo.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Cargo.UseCases
{
    public class ListCargoUseCase : IListCargoUseCase
    {
        private readonly ICargoRepository _repository;

        public ListCargoUseCase(ICargoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ListCargoResponse>>> ExecuteAsync(ListCargoRequest request)
        {
            var result = await _repository.ListAsync
                (
                    predicate: p =>
                    string.IsNullOrWhiteSpace(request.Filter) || p.Descripcion.ToUpper().Contains(request.Filter.ToUpper()),
                    selector: p => new ListCargoResponse
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        FechaCreacion = p.FechaCreacion,
                    },
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize
                );
            return Result<List<ListCargoResponse>>.Success(result.Result.ToList());
        }
    }
}
