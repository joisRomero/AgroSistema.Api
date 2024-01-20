using AgroSistema.Application.Usuario.Command.CrearUsuario;
using AgroSistema.Application.Usuario.Command.ValidarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : AbstractController
    {
        [HttpPost]
        [Route("crear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CrearUsuarioAsync([FromBody] CrearUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("validarNombreUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ValidarNombreUsuarioAsync([FromBody] ValidarNombreUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
