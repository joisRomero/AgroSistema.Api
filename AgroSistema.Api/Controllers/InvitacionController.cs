using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Application.Invitacion.CambiarEstadoInvitacionSociedadAsync;
using AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync;
using AgroSistema.Application.Invitacion.RegistrarInvitacionSociedadAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvitacionController : AbstractController
    {
        [HttpGet]
        [Route("listarInvitacionesSociedades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarInvitacionesSociedadesAsync([FromQuery] ListarInvitacionesSociedadQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("registrarInvitacionSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarInvitacionSociedadAsync([FromBody] RegistrarInvitacionSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("cambiarEstadoInvitacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CambiarEstadoInvitacionAsync([FromBody] CambiarEstadoInvitacionSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
