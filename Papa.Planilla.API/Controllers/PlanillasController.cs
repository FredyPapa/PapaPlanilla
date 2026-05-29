using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Features.Contrato.DTO;
using Papa.Planilla.Application.Features.Planilla.DTO;
using Papa.Planilla.Application.Features.Planilla.UseCases;

namespace Papa.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanillasController : BaseApiController
    {
        private readonly PlanillaUseCases _useCases;

        public PlanillasController(PlanillaUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlanillaRequest request)
        {
            var result = await _useCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListPlanillaRequest request)
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
    }
}
