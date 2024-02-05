using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
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
        [Route("editarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarCultivoAsync([FromBody] AgregarCultivoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarCultivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCultivoAsync([FromBody] AgregarCultivoCommand command)
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
