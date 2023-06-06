using AgroSistema.Application.Cosecha.GetListaPaginadaCosechas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CosechaController : AbstractController
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
