using AgroSistema.Application.TipoActividad.EliminarTipoActividad;
using AgroSistema.Application.TipoActividad.ListaPaginadaTipoActividad;
using AgroSistema.Application.TipoActividad.ModificarTipoActividad;
using AgroSistema.Application.TipoActividad.ObtenerTipoActividad;
using AgroSistema.Application.TipoActividad.RegistrarTipoActividad;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    public class TipoActividadController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaTipoActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaTipoActividadAsync([FromBody] ListaPaginadaTipoActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("registrarTipoActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarTipoActividadAsync([FromBody] RegistrarTipoActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("modificarTipoActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ModificarTipoActividadAsync([FromBody] ModificarTipoActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("eliminarTipoActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarTipoActividadAsync([FromBody] EliminarTipoActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("obtenerTipoActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerTipoActividadAsync([FromBody] ObtenerTipoActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
