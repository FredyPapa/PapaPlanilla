using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Papa.Planilla.Application.Features.Trabajador.UseCases
{
    public class ListTrabajadorUseCase : IListTrabajadorUseCase
    {
        private readonly ITrabajadorRepository _repository;

        public ListTrabajadorUseCase(ITrabajadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ListTrabajadorResponse>>> ExecuteAsync(ListTrabajadorRequest request)
        {
            var result = await _repository.ListAsync
                (
                    predicate: p => p.Estado && (
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Nombres.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.ApellidoPaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.ApellidoMaterno.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.Correo.ToUpper().Contains(request.Filter.ToUpper())) ||
                    (string.IsNullOrWhiteSpace(request.Filter) || p.NumeroCelular.Numero.Contains(request.Filter))),
                    selector: p => new ListTrabajadorResponse
                    {
                        Id = p.Id,
                        TipoDocumento = p.DocumentoIdentidad.Tipo,
                        NumeroDocumento = p.DocumentoIdentidad.Numero,
                        ApellidoPaterno = p.ApellidoPaterno,
                        ApellidoMaterno = p.ApellidoMaterno,
                        Nombres = p.Nombres,
                        Correo = p.Correo,
                        CodigoPaisCelular = p.NumeroCelular.CodigoPais,
                        NumeroCelular = p.NumeroCelular.Numero,
                        FechaCreacion = p.FechaCreacion,
                    },
                    pageNumber : request.PageNumber,
                    pageSize : request.PageSize
                );
            return Result<List<ListTrabajadorResponse>>.Success(result.Result.ToList());
        }
    }
}
