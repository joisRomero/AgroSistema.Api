using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvitacionController : AbstractController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("listarInvitacionesSociedades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> listarInvitacionesSociedadesAsync([FromQuery] ListarInvitacionesSociedadQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
