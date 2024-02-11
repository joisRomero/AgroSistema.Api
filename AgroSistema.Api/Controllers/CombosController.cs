using AgroSistema.Application.Combos.GetCalidadesCosecha;
using AgroSistema.Application.Combos.GetCultivosUsuario;
using AgroSistema.Application.Combos.GetUnidadesCampania;
using AgroSistema.Application.Combos.GetUnidadesCosecha;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CombosController : AbstractController
    {
        [HttpGet]
        [Route("obtenerUnidadesCosecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadesCosechaAsync([FromQuery] GetUnidadesCosechaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        
        [HttpGet]
        [Route("obtenerCalidadesCosecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCalidadesCosechaAsync([FromQuery] GetCalidadesCosechaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerCultivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCultivosUsuarioAsync([FromQuery] GetCultivosUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadesCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadesCampaniaAsync([FromQuery] GetUnidadesCampaniaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
