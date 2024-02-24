using AgroSistema.Application.Cosecha.GetListaPaginadaCosechas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    public class TipoActividadController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaCosechas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GeListaPaginadaCosechasAsync([FromBody] ListaPaginadaCosechasCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
