﻿using AgroSistema.Application.Actividad.AgregarActividadTrabajadorGastosAsync;
using AgroSistema.Application.Actividad.EliminarActividadAsync;
using AgroSistema.Application.Actividad.ListarActividadesPaginadoAsync;
using AgroSistema.Application.Actividad.ListarDetalleActividadAsync;
using AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActividadController : AbstractController
    {
        [HttpPost]
        [Route("agregarActividadTrabajadorGastos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarActividadTrabajadorGastosAsync([FromBody] AgregarActividadTrabajadorGastosCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("modificarActividadTrabajadorGastos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ModificarActividadTrabajadorGastosAsync([FromBody] ModificarActividadTrabajadorGastosCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("listarActividades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarActividadesPaginadoAsync([FromBody] ListarActividadesPaginadoCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("listarDetalleActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarDetalleActividadAsync([FromBody] ListarDetalleActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPost]
        [Route("eliminarActividad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarActividadAsync([FromBody] EliminarActividadCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
