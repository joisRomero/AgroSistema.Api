using AgroSistema.Application.Campania.GetListaPaginadaCampanias;
using AgroSistema.Application.Campania.ValidarCampania;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaniaController : AbstractController
    {
        [HttpPost]
        [Route("validar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ValidarCampaniaAsync([FromBody] ValidarCampaniaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerListaPaginaCampaniasUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginaCampaniasUsuarioAsync([FromBody] ListaPaginaCampaniasUsuarioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
