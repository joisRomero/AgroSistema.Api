﻿using AgroSistema.Application.Gasto.AgregarGastoDetalle;
using AgroSistema.Application.Gasto.AgregarTipoGasto;
using AgroSistema.Application.Gasto.EditarGastoDetalle;
using AgroSistema.Application.Gasto.EditarTipoGasto;
using AgroSistema.Application.Gasto.EliminarGastoDetalle;
using AgroSistema.Application.Gasto.EliminarTipoGasto;
using AgroSistema.Application.Gasto.GetGastoDetallePorId;
using AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Application.Gasto.GetTipoGasto;
using AgroSistema.Application.Sociedad.AgregarSociedad;
using AgroSistema.Application.Sociedad.EditarSociedad;
using AgroSistema.Application.Sociedad.EliminarSociedad;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GastoDetalleController : AbstractController
    {
        [HttpPost]
        [Route("obtenerListaPaginadaGastoDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListaPaginadaGastoDetalleAsync([FromBody] ListaPaginadaGastoDetalleCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("agregarGastoDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarGastoDetalleAsync([FromBody] AgregarGastoDetalleCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("editarGastoDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarGastoDetalleAsync([FromBody] EditarGastoDetalleCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("eliminarGastoDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarGastoDetalleAsync([FromBody] EliminarGastoDetalleCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerGastoDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGastoDetallePorIdAsync([FromBody] ObtenerGastoDetalleCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }


    }
}