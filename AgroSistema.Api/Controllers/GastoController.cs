using AgroSistema.Application.Gasto.AgregarTipoGasto;
using AgroSistema.Application.Gasto.EditarTipoGasto;
using AgroSistema.Application.Gasto.EliminarTipoGasto;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Application.Gasto.GetTipoGasto;
using AgroSistema.Application.Sociedad.AgregarSociedad;
using AgroSistema.Application.Sociedad.EditarSociedad;
using AgroSistema.Application.Sociedad.EliminarSociedad;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class GastoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaTipoGasto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaTipoGastoAsync([FromBody] ListaPaginadaTipoGastoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("agregarTipoGasto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarTipoGastoAsync([FromBody] AgregarTipoGastoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("editarTipoGasto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarTipoGastoAsync([FromBody] EditarTipoGastoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarTipoGasto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarTipoGastoAsync([FromBody] EliminarTipoGastoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerTipoGastoPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoGastoPorIdAsync([FromBody] ObtenerTipoGastoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
