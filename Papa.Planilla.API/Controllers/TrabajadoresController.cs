using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using System.Net;

namespace Papa.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ICreateTrabajadorUseCase _createTrabajadorUseCase;

        public TrabajadoresController(ICreateTrabajadorUseCase createTrabajadorUseCase)
        {
            _createTrabajadorUseCase = createTrabajadorUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTrabajadorRequest request)
        {
            var result = await _createTrabajadorUseCase.ExecuteAsync(request);
            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}
