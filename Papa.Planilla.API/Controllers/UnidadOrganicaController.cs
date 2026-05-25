using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Features.Cargo.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.DTO;
using Papa.Planilla.Application.Features.UnidadOrganica.UseCases;

namespace Papa.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadOrganicaController : BaseApiController
    {
        private readonly UnidadOrganicaUseCases _useCases;

        public UnidadOrganicaController(UnidadOrganicaUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUnidadOrganicaRequest request)
        {
            var result = await _useCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListUnidadOrganicaRequest request)
        {
            var result = await _useCases.list.ExecuteAsync(request);
            return HandlerResult(result);
        }
    }
}
