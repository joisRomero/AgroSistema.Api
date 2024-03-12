using AgroSistema.Application.Abono.AgregarAbono;
using AgroSistema.Application.Abono.EditarAbono;
using AgroSistema.Application.Abono.EliminarAbono;
using AgroSistema.Application.Abono.GetAbono;
using AgroSistema.Application.Abono.GetListaPaginadaAbono;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AbonoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaAbono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaAbonoAsync([FromBody] ListaPaginadaAbonoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("agregarAbono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarAbonoAsync([FromBody] AgregarAbonoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("editarAbono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarAbonoAsync([FromBody] EditarAbonoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarAbono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarAbonoAsync([FromBody] EliminarAbonoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerAbono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAbonoPorIdAsync([FromBody] ObtenerAbonoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
