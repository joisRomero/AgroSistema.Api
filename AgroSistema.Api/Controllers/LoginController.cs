using AgroSistema.Application.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : AbstractController
    {
        [HttpPost]
        [Route("obtenerUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerUsuarioAsync([FromBody] LoginCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
