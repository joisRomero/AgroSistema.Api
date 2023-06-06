using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ValidarCampaniaAsync;
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
    public class CampaniaRepository : ICampaniaRepository
    {
        private readonly IDataBase _database;
        public CampaniaRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<int> ValidarCampania(ValidarCampaniaEntity validarCampaniaEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", validarCampaniaEntity.IdUsuario);
            parameters.Add("@pIdCampania", validarCampaniaEntity.IdCampania);

            int result = 0;
            var response = await cnn.QueryAsync<int>("sp_ValidarPertenenciaCampania", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }
    }
}
