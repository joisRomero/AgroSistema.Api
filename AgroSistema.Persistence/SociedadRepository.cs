using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.EditarSociedadAsync;
using AgroSistema.Domain.Entities.EliminarSociedadAsync;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.ListaPaginadaSociedadAsync;
using AgroSistema.Domain.Entities.ModificarCultivoAsync;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
using AgroSistema.Domain.Entities.ValidarPertenenciaSociedadAsync;
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
    public class SociedadRepository : ISociedadRepository
    {
        private readonly IDataBase _database;
        public SociedadRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarSociedad(AgregarSociedadEntity agregarSociedadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@nombreSociedad", agregarSociedadEntity.NombreSociedad);
            parameters.Add("@idUsuario", agregarSociedadEntity.IdUsuario);
            parameters.Add("@usuarioInserta", agregarSociedadEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_AgregarSociedad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarSociedad(EditarSociedadEntity editarSociedadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idSociedad", editarSociedadEntity.IdSociedad);
            parameters.Add("@nombreSociedad", editarSociedadEntity.NombreSociedad);
            parameters.Add("@usuarioModifica", editarSociedadEntity.UsuarioModifica);


            await cnn.ExecuteAsync(
                "sp_EditarSociedad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarSociedad(EliminarSociedadEntity eliminarSociedadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idSociedad", eliminarSociedadEntity.IdSociedad);
            parameters.Add("@usuarioElimina", eliminarSociedadEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarSociedad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<PaginatedEntity<IEnumerable<CampaniasSociedadPaginadaEntity>>> GetListaPaginaCampaniasSocidadAsync(ListaPaginadaCampaniasSociedadEntity listaPaginadaCampaniasSociedadEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pPageNumber", listaPaginadaCampaniasSociedadEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaCampaniasSociedadEntity.PageSize);
            parameters.Add("@pIdSociedad", listaPaginadaCampaniasSociedadEntity.IdSociedad);
            parameters.Add("@pNombre", listaPaginadaCampaniasSociedadEntity.Nombre);

            var response = await cnn.QueryAsync<CampaniasSociedadPaginadaEntity>("sp_ObtenerListaPaginaCampaniasSocidad", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<CampaniasSociedadPaginadaEntity>>(listaPaginadaCampaniasSociedadEntity.PageNumber, listaPaginadaCampaniasSociedadEntity.PageSize, totalRows, response);
        }

        public async Task<PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>> GetListaPaginadaSociedadesAsync(ListaPaginadaSociedadEntity listaPaginadaSociedadEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters= new();
            parameters.Add("@pNombre", listaPaginadaSociedadEntity.Nombre);
            parameters.Add("@pPageNumber", listaPaginadaSociedadEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaSociedadEntity.PageSize);
            parameters.Add("@pIdUsuario", listaPaginadaSociedadEntity.IdUsuario);

            var response = await cnn.QueryAsync<SociedadPaginadaEntity>("sp_ObtenerListaPaginadaSociedades", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>(listaPaginadaSociedadEntity.PageNumber, listaPaginadaSociedadEntity.PageSize, totalRows, response);
        }

        public async Task<IEnumerable<ListaBusquedaIntegranteEntity>> ListaBusquedaIntegranteAsync(BusquedaIntegranteEntity busquedaIntegranteEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_nombreUsuario", busquedaIntegranteEntity.Nombre);
            parameters.Add("@p_idUsuario", busquedaIntegranteEntity.IdUsuario);
            
            var result = await cnn.QueryAsync<ListaBusquedaIntegranteEntity>("sp_busqueda_integrantes", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);
            
            return result;
        }

        public async Task<PaginatedEntity<IEnumerable<ListaPaginadaSociedadesEntity>>> ListarSociedades(RequestListaPaginadaSociedadesEntity requestListaPaginadaSociedadesEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@nombreSociedad", requestListaPaginadaSociedadesEntity.NombreSociedad ?? string.Empty, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@idUsuario", requestListaPaginadaSociedadesEntity.IdUsuario ?? default, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@pageSize", requestListaPaginadaSociedadesEntity.PageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@pageNumber", requestListaPaginadaSociedadesEntity.PageNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var response = await cnn.QueryAsync<ListaPaginadaSociedadesEntity>("sp_ListarSociedades", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().CantidadRegistros : 0;
            return new PaginatedEntity<IEnumerable<ListaPaginadaSociedadesEntity>>(requestListaPaginadaSociedadesEntity.PageNumber, requestListaPaginadaSociedadesEntity.PageSize, totalRows, response);
        }

        public async Task<PaginatedEntity<IEnumerable<IntegrantesSociedadEntity>>> ObtenerIntegrantesSociedadAsync(ListaPaginadaIntegrantesSociedadEntity listaPaginadaIntegrantesSociedad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdSociedad", listaPaginadaIntegrantesSociedad.IdSociedad);
            parameters.Add("@pNombre", listaPaginadaIntegrantesSociedad.Nombre);
            parameters.Add("@pPageNumber", listaPaginadaIntegrantesSociedad.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaIntegrantesSociedad.PageSize);

            var response = await cnn.QueryAsync<IntegrantesSociedadEntity>("sp_ObtenerIntegrantesSociedad", parameters,
                                                              commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<IntegrantesSociedadEntity>>(listaPaginadaIntegrantesSociedad.PageNumber, listaPaginadaIntegrantesSociedad.PageSize, totalRows, response);
        }

        public async Task<ValidarPertenenciaSociedadEntity> ValidarPertenenciaSociedad(int idUsuario, int idSociedad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", idUsuario);
            parameters.Add("@pIdSociedad", idSociedad);

            ValidarPertenenciaSociedadEntity result = new();
            var response = await cnn.QueryAsync<ValidarPertenenciaSociedadEntity>("sp_ValidarPertenenciaSociedad", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }
    }
}
