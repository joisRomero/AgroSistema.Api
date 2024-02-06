using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Application.Cultivo.EliminarCultivosAsync;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Application.Cultivo.ModificarCultivosAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CultivoController : AbstractController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("agregarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarCultivoAsync([FromBody] AgregarCultivoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("editarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarCultivoAsync([FromBody] ModificarCultivoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("eliminarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCultivoAsync([FromBody] EliminarCultivosCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("listarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> listarCultivoAsync([FromQuery] ListarCultivosQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
