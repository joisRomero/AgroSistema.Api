using AgroSistema.Application.Actividad.AgregarActividadTrabajadorGastosAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActividadController : AbstractController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("agregarActividadTrabajadorGastos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarActividadTrabajadorGastosAsync([FromBody] AgregarActividadTrabajadorGastosCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
