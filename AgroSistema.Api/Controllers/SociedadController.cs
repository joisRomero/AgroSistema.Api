using AgroSistema.Application.Sociedad.GetListaPaginadaCampaniasSocidad;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SociedadController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaSociedades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GeListaPaginadaSociedadesAsync([FromBody] ListaPaginadaSociedadesCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        
        [HttpPost]
        [Route("obtenerIntegrantesSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GeIntegrantesSociedadAsync([FromBody] ObtenerIntegrantesSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerListaPaginaCampaniasSocidad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginaCampaniasSocidadAsync([FromBody] ListaPaginaCampaniasSocidadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        
    }
}
