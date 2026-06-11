using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.UseCases;
using Papa.Planilla.Application.Results;
using Papa.Planilla.Domain.Entities;
using System.ServiceModel.Channels;

namespace Papa.Planilla.SOAP.Endpoints.Trabajador
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly TrabajadorUseCases _useCases;

        public TrabajadorService(TrabajadorUseCases useCases)
        {
            _useCases = useCases;
        }
        public async Task<BaseResponse<string>> CreateTrabajadorAsync(CreateTrabajadorRequest request)
        {
            var result = await _useCases.create.ExecuteAsync(request);
            return new()
            {
                ErrorCode = result.ErrorCode,
                IsSuccess = result.IsSuccess,
                Message = result.Message!
            };
        }

        public async Task<BaseResponse<List<ListTrabajadorResponse>>> ListTrabajadorAsync(ListTrabajadorRequest request)
        {
            // Invocamos el caso de uso de consulta
            var result = await _useCases.list.ExecuteAsync(request);

            return new BaseResponse<List<ListTrabajadorResponse>>()
            {
                ErrorCode = result.ErrorCode,
                IsSuccess = result.IsSuccess,
                Message = result.Message!,

                // ¡AQUÍ INYECTAS LA DATA! Asigna la lista de objetos al DTO de respuesta
                Data = result.Data // Ajusta 'result.Data' o la propiedad real que use tu objeto Result
            }
                    ;
        }
    }
}
