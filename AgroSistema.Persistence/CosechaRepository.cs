using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
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
    public class CosechaRepository : ICosechaRepository
    {
        private readonly IDataBase _database;
        public CosechaRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>> GetListaPaginadaCosechasAsync(ListaPaginadaCosechasEntity listaPaginadaCosechasEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdCampania", listaPaginadaCosechasEntity.IdCampania);
            parameters.Add("@pPageNumber", listaPaginadaCosechasEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaCosechasEntity.PageSize);

            var response = await cnn.QueryAsync<CosechaPaginadaEntity>("sp_ObtenerListaPaginadaCosechas", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>(listaPaginadaCosechasEntity.PageNumber, listaPaginadaCosechasEntity.PageSize, totalRows, response);
        }
    }
}
