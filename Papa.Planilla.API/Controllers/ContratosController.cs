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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _useCases.getById.ExecuteAsync(id);
            return HandlerResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContratoRequest request)
        {
            var result = await _useCases.update.ExecuteAsync(request);
            return HandlerResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _useCases.delete.ExecuteAsync(id);
            return HandlerResult(result);
        }
    }
}
