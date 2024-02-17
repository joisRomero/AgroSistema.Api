using AgroSistema.Application.Usuario.Command.ActualizarClavesUsuario;
using AgroSistema.Application.Usuario.Command.ActualizarDatosUsuario;
using AgroSistema.Application.Usuario.Command.CrearUsuario;
using AgroSistema.Application.Usuario.Command.EliminarCuentaUsuario;
using AgroSistema.Application.Usuario.Command.GenerarCodigoRecuperacionCuenta;
using AgroSistema.Application.Usuario.Command.ValidarUsuario;
using AgroSistema.Application.Usuario.Query.ObtenerDatosUsuario;
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
        [Route("validarNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ValidarNombreUsuarioAsync([FromBody] ValidarNombreUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerDatos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerDatosUsuarioAsync([FromQuery] ObtenerDatosUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("actualizarDatos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarDatosUsuarioAsync([FromBody] ActualizarDatosUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("actualizarClaves")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarClavesUsuarioAsync([FromBody] ActualizarClavesUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCuentaUsuarioAsync([FromBody] EliminarCuentaUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("generarCodigoRecuperacionCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerarCodigoRecuperacionCuentaAsync([FromBody] GenerarCodigoRecuperacionCuentaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
