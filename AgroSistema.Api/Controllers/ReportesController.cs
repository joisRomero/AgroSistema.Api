using AgroSistema.Application.Reportes.ReporteInicioAsync;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportesController : AbstractController
    {
        [HttpPost]
        [Route("reporteInicio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReporteInicioAsync([FromBody] ReporteInicioCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
