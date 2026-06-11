using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Results;
using System.ServiceModel;

namespace Papa.Planilla.SOAP.Endpoints.Trabajador
{
    [ServiceContract]
    public interface ITrabajadorService
    {
        [OperationContract]
        Task<BaseResponse<string>> CreateTrabajadorAsync(CreateTrabajadorRequest request);
        
        [OperationContract]
        Task<BaseResponse<List<ListTrabajadorResponse>>> ListTrabajadorAsync(ListTrabajadorRequest request);
    }
}
