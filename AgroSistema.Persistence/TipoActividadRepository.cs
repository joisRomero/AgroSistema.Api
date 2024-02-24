using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.EliminarTipoActividadAsync;
using AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync;
using AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.ModificarTipoActividadAsync;
using AgroSistema.Domain.Entities.ObtenerTipoActividadAsync;
using AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.RegistrarTipoActividadAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AgroSistema.Persistence
{
    public class TipoActividadRepository : ITipoActividad
    {
        private readonly IDataBase _database;
        public TipoActividadRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task EliminarTipoActividadAsync(EliminarTipoActividadEntity eliminarTipoActividadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoActi", eliminarTipoActividadEntity.IdTipoActividad);
            parameters.Add("@p_usuarioElimina_tipoActi", eliminarTipoActividadEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_eliminar_tipo_actividad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<PaginatedEntity<IEnumerable<ListaPaginadaTipoActividadEntity>>> ListaPaginadaTipoActividadAsync(RequestListaPaginadaTipoActividadEntity entity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_tipoActi", entity.NombreTipoActividad ?? string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@p_realizadaPor_tipoActi", entity.RealizadaPorTipoActividad ?? string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@p_id_usu", entity.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@p_PageSize", entity.PageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@p_PageNumber", entity.PageNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ListaPaginadaTipoActividadEntity>("sp_listar_tipo_actividad", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<ListaPaginadaTipoActividadEntity>>(entity.PageNumber, entity.PageSize, totalRows, response);

        }

        public async Task ModificarTipoActividadAsync(ModificarTipoActividadEntity modificarTipoActividadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoActi", modificarTipoActividadEntity.IdTipoActividad);
            parameters.Add("@p_nombre_tipoActi", modificarTipoActividadEntity.NombreTipoActividad);
            parameters.Add("@p_realizadaPor_tipoActi", modificarTipoActividadEntity.RealizadaPorTipoActividad);
            parameters.Add("@p_descripcion_tipoActi", modificarTipoActividadEntity.DescripcionTipoActividad);
            parameters.Add("@p_usuarioModifica_tipoActi", modificarTipoActividadEntity.UsuarioModifica);

            await cnn.ExecuteAsync(
                "sp_editar_tipo_actividad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerTipoActividadEntity> ObtenerTipoActividadAsync(int idTipoActividad)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoActi", idTipoActividad, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ObtenerTipoActividadEntity>("sp_obtener_tipo_actividad", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            var result = response.First();

            return result;
        }

        public async Task RegistrarTipoActividadAsync(RegistrarTipoActividadEntity registrarTipoActividadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_tipoActi", registrarTipoActividadEntity.NombreTipoActividad);
            parameters.Add("@p_realizadaPor_tipoActi", registrarTipoActividadEntity.RealizadaPorTipoActividad);
            parameters.Add("@p_descripcion_tipoActi", registrarTipoActividadEntity.DescripcionTipoActividad);
            parameters.Add("@p_id_usu", registrarTipoActividadEntity.IdUsuario);
            parameters.Add("@p_usuarioInserta_tipoActi", registrarTipoActividadEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_crear_tipo_actividad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
