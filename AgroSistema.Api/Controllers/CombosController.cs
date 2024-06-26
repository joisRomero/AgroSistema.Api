﻿using AgroSistema.Application.Combos.GetAbonoUsuarioAsync;
using AgroSistema.Application.Combos.GetAgroquimicoUsuarioAsync;
using AgroSistema.Application.Combos.GetCalidadesCosecha;
using AgroSistema.Application.Combos.GetCultivosUsuario;
using AgroSistema.Application.Combos.GetTipoActividadXUsuario;
using AgroSistema.Application.Combos.GetTipoAgroquimico;
using AgroSistema.Application.Combos.GetTipoGastoXUsuario;
using AgroSistema.Application.Combos.GetTipoTrabajadorXUsuario;
using AgroSistema.Application.Combos.GetUnidadAbonacion;
using AgroSistema.Application.Combos.GetUnidadesCampania;
using AgroSistema.Application.Combos.GetUnidadesCosecha;
using AgroSistema.Application.Combos.GetUnidadFumigacion;
using AgroSistema.Application.Combos.GetUnidadFumigacionDetalle;
using AgroSistema.Application.Combos.GetUnidadSemilla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroSistema.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CombosController : AbstractController
    {
        [HttpGet]
        [Route("obtenerUnidadesCosecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadesCosechaAsync([FromQuery] GetUnidadesCosechaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        
        [HttpGet]
        [Route("obtenerCalidadesCosecha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCalidadesCosechaAsync([FromQuery] GetCalidadesCosechaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerCultivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCultivosUsuarioAsync([FromQuery] GetCultivosUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadesCampania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadesCampaniaAsync([FromQuery] GetUnidadesCampaniaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoTrabajadorPorUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoTrabajadorXUsuarioAsync([FromQuery] TipoTrabajadorXUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoActividadPorUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoActividadXUsuarioAsync([FromQuery] TipoActividadXUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipGastoPorUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoGastoXUsuarioAsync([FromQuery] TipoGastoXUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoAgroquimico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoAgroquimicoAsync([FromQuery] TipoAgroquimicoQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadAbonacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadAbonacionAsync([FromQuery] UnidadAbonacionQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadFumigacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadFumigacionAsync([FromQuery] UnidadFumigacionQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadFumigacionDetalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadFumigacionDetalleAsync([FromQuery] UnidadFumigacionDetalleQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerUnidadSemilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnidadSemillaAsync([FromQuery] UnidadSemillaQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        [HttpGet]
        [Route("obtenerAbonoUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAbonoUsuarioAsync([FromQuery] GetAbonoUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        [HttpGet]
        [Route("obtenerAgroquimicoUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAgroquimicoUsuarioAsync([FromQuery] GetAgroquimicoUsuarioQuery query)
        {
            var response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
