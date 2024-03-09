using AgroSistema.Application.Notificacion.AgregarNotificacion;
using AgroSistema.Application.Notificacion.ListarNotificaciones;
using AgroSistema.Application.Usuario.Command.CrearUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class NotificacionController : AbstractController
    {
        [HttpPost]
        [Route("agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarNotificacionAsync([FromBody] AgregarNotificacionCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarNotificacionesAsync([FromBody] ListarNotificacionesCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
