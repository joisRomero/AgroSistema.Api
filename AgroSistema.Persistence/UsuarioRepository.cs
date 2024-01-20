using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.CrearUsuarioAsync;
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
