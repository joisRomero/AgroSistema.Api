using AgroSistema.Application.Cosecha.GetListaPaginadaCosechas;
using AgroSistema.Application.TipoTrabajador.EliminarTipoTrabajador;
using AgroSistema.Application.TipoTrabajador.ListaPaginadaTipoTrabajador;
using AgroSistema.Application.TipoTrabajador.ModificarTipoTrabajador;
using AgroSistema.Application.TipoTrabajador.ObtenerTipoTrabajador;
using AgroSistema.Application.TipoTrabajador.RegistrarTipoTrabajador;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    public class TipoTrabajadorController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaTipoTrabajador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaTipoTrabajadorAsync([FromBody] ListaPaginadaTipoTrabajadorCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("registrarTipoTrabajador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarTipoTrabajadorAsync([FromBody] RegistrarTipoTrabajadorCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("modificarTipoTrabajador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ModificarTipoTrabajadorAsync([FromBody] ModificarTipoTrabajadorCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("eliminarTipoTrabajador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarTipoTrabajadorAsync([FromBody] EliminarTipoTrabajadorCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("obtenerTipoTrabajador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetObtenerTipoTrabajadorAsync([FromBody] ObtenerTipoTrabajadorCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
