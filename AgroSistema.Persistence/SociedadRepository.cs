using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.LoginAsync;
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
            int pageNumber = listaPaginadaCampaniasSociedadEntity.PageNumber;
            int pageSize = listaPaginadaCampaniasSociedadEntity.PageSize;
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pPageNumber", pageNumber);
            parameters.Add("@pPageSize", pageSize);
            parameters.Add("@pIdSociedad", listaPaginadaCampaniasSociedadEntity.IdSociedad);

            var response = await cnn.QueryAsync<CampaniasSociedadPaginadaEntity>("sp_ObtenerListaPaginaCampaniasSocidad", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return new PaginatedEntity<IEnumerable<CampaniasSociedadPaginadaEntity>>(pageNumber, pageSize, response.Count(), response);
        }

        public async Task<PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>> GetListaPaginadaSociedadesAsync(ListaPaginadaSociedadEntity listaPaginadaSociedadEntity)
        {
            int pageNumber = listaPaginadaSociedadEntity.PageNumber;
            int pageSize = listaPaginadaSociedadEntity.PageSize;
            using var cnn = _database.GetConnection();
            DynamicParameters parameters= new();
            parameters.Add("@pNombre", listaPaginadaSociedadEntity.Nombre);
            parameters.Add("@pPageNumber", pageNumber);
            parameters.Add("@pPageSize", pageSize);
            parameters.Add("@@pIdUsuario", listaPaginadaSociedadEntity.IdUsuario);

            var response = await cnn.QueryAsync<SociedadPaginadaEntity>("sp_ObtenerListaPaginadaSociedades", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return new PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>(pageNumber, pageSize, response.Count(), response);
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
