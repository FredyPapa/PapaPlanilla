using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Contrato.UseCases;

namespace Papa.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : BaseApiController
    {
        private readonly ContratoUseCases _useCases;

        public ContratosController(ContratoUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContratoRequest request)
        {
            var result = await _useCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListContratoRequest request)
        {
            var result = await _useCases.list.ExecuteAsync(request);
            return HandlerResult(result);
        }
    }
}
