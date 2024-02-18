using AgroSistema.Application.Campania.EditarCampaniaAsync;
using AgroSistema.Application.Campania.EliminarCampaniaAsync;
using AgroSistema.Application.Campania.FinalizarCampaniaAsync;
using AgroSistema.Application.Campania.GetListaPaginadaCampanias;
using AgroSistema.Application.Campania.RegistrarCamapaniaAsync;
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

        [HttpPost]
        [Route("registrarCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarCamapaniaAsync([FromBody] RegistrarCampaniaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("editarCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarCampaniaAsync([FromBody] EditarCampaniaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("eliminarCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCampaniaAsync([FromBody] EliminarCampaniaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("finalizarCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FinalizarCampaniaAsync([FromBody] FinalizarCampaniaCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
