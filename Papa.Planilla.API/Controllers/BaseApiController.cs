using Microsoft.AspNetCore.Mvc;
using Papa.Planilla.Application.Results;

namespace Papa.Planilla.API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult HandlerResult(Result result)
        {
            //Si se ejecutó correctamente
            if (result.IsSuccess) return Ok(result);

            //Si hubo errores, se devuelve un BadRequest con los errores y la hora actual
            if (result.Errors.Any())
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    result.Errors,
                    TimeSpan = DateTime.Now
                });
            }
            
            //Si hubo un error
            return BadRequest(result);
        }
    }
}
