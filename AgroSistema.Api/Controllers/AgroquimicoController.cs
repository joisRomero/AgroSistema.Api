using AgroSistema.Application.Agroquimico.AgregarAgroquimico;
using AgroSistema.Application.Agroquimico.EditarAgroquimico;
using AgroSistema.Application.Agroquimico.EliminarAgroquimico;
using AgroSistema.Application.Agroquimico.GetAgroquimico;
using AgroSistema.Application.Agroquimico.GetListaPaginadaAgroquimico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AgroquimicoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaAgroquimicoAsync([FromBody] ListaPaginadaAgroquimicoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("agregarAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarAgroquimicoAsync([FromBody] AgregarAgroquimicoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("editarAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarAgroquimicoAsync([FromBody] EditarAgroquimicoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarAgroquimicoAsync([FromBody] EliminarAgroquimicoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAgroquimicoPorIdAsync([FromBody] ObtenerAgroquimicoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
