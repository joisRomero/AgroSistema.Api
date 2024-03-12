using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
using AgroSistema.Domain.Entities.GetCultivosUsuarioaAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using AgroSistema.Domain.Entities.GetTipoActividadXUsuarioAsync;
using AgroSistema.Domain.Entities.GetTipoAgroquimicoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoXUsuarioAsync;
using AgroSistema.Domain.Entities.GetTipoTrabajadorXUsuarioAsync;
using AgroSistema.Domain.Entities.GetUnidadesCampaniaAsync;
using AgroSistema.Domain.Entities.GetUnidadesCosechaAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Persistence
{
    public class CombosRepository : ICombosRepository
    {
        private readonly IDataBase _database;
        public CombosRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<IEnumerable<CalidadesCosechaEntity>> GetCalidadesCosechaAsync()
        {
            using var cnn = _database.GetConnection();
            var response = await cnn.QueryAsync<CalidadesCosechaEntity>("sp_ObtenerCalidadesCosecha", 
                                    commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<CultivosUsuarioEntity>> GetCultivosUsuarioAsync(int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", idUsuario);

            var response = await cnn.QueryAsync<CultivosUsuarioEntity>("sp_ObtenerCultivosUsuario",
                                    parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<UnidadesCampaniaEntity>> GetUnidadesCampaniaAsync()
        {
            using var cnn = _database.GetConnection();
            var response = await cnn.QueryAsync<UnidadesCampaniaEntity>("sp_ObtenerUnidadesCampania",
                                    commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<UnidadesCosechaEntity>> GetUnidadesCosechaAsync()
        {
            using var cnn = _database.GetConnection();
            var response = await cnn.QueryAsync<UnidadesCosechaEntity>("sp_ObtenerUnidadesCosecha", 
                                    commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<TipoActividadXUsuarioEntity>> GetTipoActividadXUsuarioAsync(int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<TipoActividadXUsuarioEntity>("sp_obtener_x_usuario_tipo_actividad",
                                    parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<TipoTrabajadorXUsuarioEntity>> GetTipoTrabajadorXUsuarioAsync(int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<TipoTrabajadorXUsuarioEntity>("sp_obtener_x_usuario_tipo_trabajador",
                                    parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<TipoGastoXUsuarioEntity>> GetTipoGastoXUsuarioAsync(int idUsuario)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<TipoGastoXUsuarioEntity>("sp_obtener_x_usuario_tipo_gasto",
                                    parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<GetTipoAgroquimicoEntity>> GetTipoAgroquimicoAsync()
        {
            using var cnn = _database.GetConnection();
            var response = await cnn.QueryAsync<GetTipoAgroquimicoEntity>("sp_listar_tipo_agroquimico",
                                    commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
