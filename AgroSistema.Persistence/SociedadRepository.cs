using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
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

        public async Task<IEnumerable<IntegrantesSociedadEntity>> ObtenerIntegrantesSociedadAsync(int idSociedad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdSociedad", idSociedad);

            var response = await cnn.QueryAsync<IntegrantesSociedadEntity>("sp_ObtenerIntegrantesSociedad", parameters,
                                                              commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<int> ValidarPertenenciaSociedad(int idUsuario, int idSociedad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", idUsuario);
            parameters.Add("@pIdSociedad", idSociedad);

            int result = 0;
            var response = await cnn.QueryAsync<int>("sp_ValidarPertenenciaSociedad", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }
    }
}
