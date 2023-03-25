using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
    }
}
