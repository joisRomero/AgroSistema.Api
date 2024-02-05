using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.EliminarCultivoAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AgroSistema.Domain.Entities.ModificarCultivoAsync;
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
    public class CultivoRepository : ICultivoRepository
    {
        private readonly IDataBase _dataBase;

        public CultivoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarCultivo(AgregarCultivoEntity agregarCultivoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_culti", agregarCultivoEntity.NombreCultivo);
            parameters.Add("@p_id_usu", agregarCultivoEntity.IdUsuario);
            parameters.Add("@p_usuarioInserta_culti", agregarCultivoEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_crear_cultivo", 
                param: parameters, 
                commandType: CommandType.StoredProcedure);
        }
        public async Task ModificarCultivo(ModificarCultivoEntity modificarCultivoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_culti", modificarCultivoEntity.IdCultivo);
            parameters.Add("@p_nombre_culti", modificarCultivoEntity.NombreCultivo);
            parameters.Add("@p_id_usu", modificarCultivoEntity.IdUsuario);
            parameters.Add("@p_usuarioModifica_culti", modificarCultivoEntity.UsuarioModifica);
            

            await cnn.ExecuteAsync(
                "sp_editar_cultivo",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarCultivo(EliminarCultivoEntity eliminarCultivoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_culti", eliminarCultivoEntity.IdCultivo);
            parameters.Add("@p_usuarioElimina_culti", eliminarCultivoEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_eliminar_cultivo",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<PaginatedEntity<IEnumerable<ListaPaginadaCultivoEntity>>> ListarCultivosAsync(RequestListaPaginadaCultivoEntity requestListaPaginadaCultivoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombre_culti", requestListaPaginadaCultivoEntity.NombreCultivo ?? string.Empty ,dbType: DbType.String,direction: ParameterDirection.Input);
            parameters.Add("@p_id_usu", requestListaPaginadaCultivoEntity.IdUsuario ?? default, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@p_PageSize", requestListaPaginadaCultivoEntity.PageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@p_PageNumber", requestListaPaginadaCultivoEntity.PageNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ListaPaginadaCultivoEntity>("sp_listar_cultivos", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().CantidadRegistros : 0;
            return new PaginatedEntity<IEnumerable<ListaPaginadaCultivoEntity>>(requestListaPaginadaCultivoEntity.PageNumber, requestListaPaginadaCultivoEntity.PageSize, totalRows, response);
        }
    }
}
