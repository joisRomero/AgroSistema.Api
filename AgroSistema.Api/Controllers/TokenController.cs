using AgroSistema.Application.TokenUsuario.CrearTokenUsuarioAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : AbstractController
    {
        [HttpPost]
        [Route("tokenUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CrearTokenUsuarioAsync([FromBody] CrearTokenUsuarioCommand command, [FromHeader(Name = "Client-Id")] Guid clientId)
        {
            command.ClientId = clientId;

            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
