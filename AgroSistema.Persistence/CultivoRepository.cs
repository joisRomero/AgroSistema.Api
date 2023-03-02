using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
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
            parameters.Add("@pNombre", agregarCultivoEntity.Nombre);
            parameters.Add("@pEstado", agregarCultivoEntity.Estado);
            parameters.Add("@pCodUsuario", agregarCultivoEntity.CodUsuario);

            _ = await cnn.ExecuteAsync("sp_AgregarCultivo", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
