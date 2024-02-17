using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ActualizarDatosUsuario;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.CambiarClaveRecuperacionCuentaAsync;
using AgroSistema.Domain.Entities.CrearUsuarioAsync;
using AgroSistema.Domain.Entities.ObtenerDatosUsuarioAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Persistence
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDataBase _database;
        public UsuarioRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<int> ActualizarClavesUsuario(string claveNueva, int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pClave", claveNueva);
            parameters.Add("@pIdUsuario", idUsuario);

            var response = await cnn.QueryAsync<int>("sp_ActualizarClavesUsuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<ResponseDatosUsuarioEntity> ActualizarDatosUsuario(ActualizarDatosUsuarioEntity actualizarDatosUsuarioEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", actualizarDatosUsuarioEntity.Id);
            parameters.Add("@pNombre", actualizarDatosUsuarioEntity.Nombre);
            parameters.Add("@pApellidoPaterno", actualizarDatosUsuarioEntity.ApellidoPaterno);
            parameters.Add("@pApellidoMaterno", actualizarDatosUsuarioEntity.ApellidoMaterno);
            parameters.Add("@pCorreo", actualizarDatosUsuarioEntity.Correo);

            var response = await cnn.QueryAsync<ResponseDatosUsuarioEntity>("sp_ActualizarUsuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<CambiarClaveRecuperacionCuentaEntity> CambiarClaveRecuperacionCuenta(string? clave, string? correo)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@nuevaClave", clave);
            parameters.Add("@correo", correo);

            var response = await cnn.QueryAsync<CambiarClaveRecuperacionCuentaEntity>("sp_CambioClaveUsuarioRecuperacion", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<ResponseCrearUsuarioEntity> CrearUsuario(CrearUsuarioEntity crearUsuarioEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pNombreUsuario", crearUsuarioEntity.NombreUsuario);
            parameters.Add("@pClave", crearUsuarioEntity.Clave);
            parameters.Add("@pNombre", crearUsuarioEntity.Nombre);
            parameters.Add("@pApellidoPaterno", crearUsuarioEntity.ApellidoPaterno);
            parameters.Add("@pApellidoMaterno", crearUsuarioEntity.ApellidoMaterno);
            parameters.Add("@pCorreo", crearUsuarioEntity.Correo);

            var response = await cnn.QueryAsync<ResponseCrearUsuarioEntity>("sp_CrearUsuario", parameters, commandTimeout: 0,commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task EliminarCuentaUsuario(int idUsuario)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", idUsuario);

            _ = await cnn.ExecuteAsync("sp_EliminarUsuario", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerDatosUsuarioEntity> ObtenerDatosUsuario(int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", idUsuario);

            var response = await cnn.QueryAsync<ObtenerDatosUsuarioEntity>("sp_ObtenerDatosUsuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.FirstOrDefault();
        }

        public async Task<int> ValidarClaveActual(string claveActual, int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pClave", claveActual);
            parameters.Add("@pIdUsuario", idUsuario);

            var response = await cnn.QueryAsync<int>("sp_ValidarClavesUsuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<bool> ValidarUsuario(string nombreUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pNombreUsuario", nombreUsuario);

            var response = await cnn.QueryAsync<bool>("sp_ValidarNombreUsuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }
    }
}
