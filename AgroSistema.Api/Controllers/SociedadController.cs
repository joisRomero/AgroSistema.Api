using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Application.Sociedad.AgregarSociedad;
using AgroSistema.Application.Sociedad.AsignarAdministradorSociedad;
using AgroSistema.Application.Sociedad.EditarSociedad;
using AgroSistema.Application.Sociedad.EliminarSociedad;
using AgroSistema.Application.Sociedad.GetListaPaginadaCampaniasSocidad;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using AgroSistema.Application.Sociedad.ListaBusquedaIntegrante;
using AgroSistema.Application.Sociedad.ListarSociedad;
using AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad;
using AgroSistema.Application.Sociedad.ValidarPertenenciaSociendad;
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
        public async Task<IActionResult> GetListaPaginadaSociedadesAsync([FromBody] ListaPaginadaSociedadesCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        
        [HttpPost]
        [Route("obtenerIntegrantesSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIntegrantesSociedadAsync([FromBody] ObtenerIntegrantesSociedadCommand command)
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

        [HttpPost]
        [Route("agregarSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarSociedadAsync([FromBody] AgregarSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("editarSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarSociedadAsync([FromBody] EditarSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarSociedadAsync([FromBody] EliminarSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Route("listarSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarSociedadAsync([FromQuery] ListarSociedadQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("validarPertenenciaSociedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ValidarPertenenciaSociendadAsync([FromBody] ValidarPertenenciaSociendadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("busquedaIntegrante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaBusquedaIntegranteAsync([FromBody] ListaBusquedaIntegranteCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("asignarAdministrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AsignarAdministradorAsync([FromBody] AsignarAdministradorSociedadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
