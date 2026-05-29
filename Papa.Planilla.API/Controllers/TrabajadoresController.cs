using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Features.Trabajador.DTO;
using Papa.Planilla.Application.Features.Trabajador.Ports;
using Papa.Planilla.Application.Features.Trabajador.UseCases;
using System.Net;

namespace Papa.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : BaseApiController
    {
        private readonly TrabajadorUseCases _useCases;

        public TrabajadoresController(TrabajadorUseCases useCases)
        {
            _useCases = useCases;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTrabajadorRequest request)
        {
            var result = await _useCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListTrabajadorRequest request)
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
        public async Task<IActionResult> Put([FromBody] UpdateTrabajadorRequest request)
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
