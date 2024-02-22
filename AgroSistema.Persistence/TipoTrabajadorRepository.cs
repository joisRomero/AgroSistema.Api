using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.EliminarTipoTrabjadorAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.ModificarTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.RegistrarTipoTrabajadorAsync;
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
    public  class TipoTrabajadorRepository : ITipoTrabajador
    {
        private readonly IDataBase _database;
        public TipoTrabajadorRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task RegistrarTipoTrabajadorAsync(RegistrarTipoTrabajadorEntity entity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_tipoTrab", entity.NombreTipoTrabajador);
            parameters.Add("@p_descripcion_tipoTrab", entity.DescripcionTipoTrabajador);
            parameters.Add("@p_usuarioInserta_tipoTrab", entity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_crear_tipo_trabajador",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task ModificarTipoTrabajadorAsync(ModificarTipoTrabajadorEntity entity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoTrab", entity.IdTipoTrabajador);
            parameters.Add("@p_nombre_tipoTrab", entity.NombreTipoTrabajador);
            parameters.Add("@p_descripcion_tipoTrab", entity.DescripcionTipoTrabajador);
            parameters.Add("@p_usuarioModifica_tipoTrab", entity.UsuarioModifica);

            await cnn.ExecuteAsync(
                "sp_modificar_tipo_trabajador",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarTipoTrabjadorAsync(EliminarTipoTrabajadorEntity eliminarTipoTrabajadorEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoTrab", eliminarTipoTrabajadorEntity.IdTipoTrabajador);
            parameters.Add("@p_usuarioElimina_tipoTrab", eliminarTipoTrabajadorEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_eliminar_tipo_trabajador",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async  Task<PaginatedEntity<IEnumerable<ListaPaginadaTipoTrabajadorEntity>>> ListarPaginadaTipoTrabajadorAsync(RequestListaPaginadaTipoTrabajadorEntity entity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_tipoTrab", entity.NombreTipoTrabajador ?? string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@p_PageSize", entity.PageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@p_PageNumber", entity.PageNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ListaPaginadaTipoTrabajadorEntity>("sp_listar_tipo_trabajador", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<ListaPaginadaTipoTrabajadorEntity>>(entity.PageNumber, entity.PageSize, totalRows, response);

        }

        public async Task<ObtenerTipoTrabajadorEntity> ObtenerTipoTrabajadorAsync(int idTipoTrabajador)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_tipoTrab", idTipoTrabajador, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ObtenerTipoTrabajadorEntity>("sp_listar_tipo_trabajador", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            var result = response.First();

            return result;
        }
    }
}
