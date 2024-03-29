﻿using AgroSistema.Domain.Entities.ActualizarDatosUsuario;
using AgroSistema.Domain.Entities.CambiarClaveRecuperacionCuentaAsync;
using AgroSistema.Domain.Entities.CrearUsuarioAsync;
using AgroSistema.Domain.Entities.GuardarTokenRecuperacion;
using AgroSistema.Domain.Entities.ObtenerDatosUsuarioAsync;
using AgroSistema.Domain.Entities.ValidarCodigoRecuperacionCuentaAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ResponseCrearUsuarioEntity> CrearUsuario(CrearUsuarioEntity crearUsuarioEntity);
        Task<bool> ValidarUsuario(string nombreUsuario);
        Task<ObtenerDatosUsuarioEntity> ObtenerDatosUsuario(int idUsuario);
        Task<ResponseDatosUsuarioEntity> ActualizarDatosUsuario(ActualizarDatosUsuarioEntity actualizarDatosUsuarioEntity);
        Task<int> ActualizarClavesUsuario(string claveNueva, int idUsuario);
        Task<int> ValidarClaveActual(string claveActual, int idUsuario);
        Task EliminarCuentaUsuario(int idUsuario);
        Task<bool> ValidateExistsCorreoAsync(string correo);
        Task<string> ObtenerNombreCompletoCorreoAsync(string correo);
        Task GuardarTokenRecuperacionAsync(GuardarTokenRecuperacionEntity guardarTokenRecuperacionEntity);
        Task<bool> ValidarCodigoRecuperacionCuenta(ValidarTokenRecoveryAcountEntity validarTokenRecoveryAcountEntity);
        Task<CambiarClaveRecuperacionCuentaEntity> CambiarClaveRecuperacionCuenta(string? clave, string? correo);
        Task<bool> ValidarCorreoUnicoAsync(string correo);
    }
}
