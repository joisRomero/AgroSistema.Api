using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
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

        public async Task<IEnumerable<UnidadesCosechaEntity>> GetUnidadesCosechaAsync()
        {
            using var cnn = _database.GetConnection();
            var response = await cnn.QueryAsync<UnidadesCosechaEntity>("sp_ObtenerUnidadesCosecha", 
                                    commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
