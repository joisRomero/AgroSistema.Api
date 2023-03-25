using Dapper;
using Microsoft.Extensions.DependencyInjection;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Domain.Entities;
using AgroSistema.Persistence.DataBase;
using System.Data;

namespace AgroSistema.Persistence
{
    public class MensajeUsuarioRepository : IMensajeUsuarioRepository
    {
        private readonly IDataBase _database;

        public MensajeUsuarioRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<MensajeUsuarioEntity>> GetListaAsync(Guid aplicacionGuid)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@aplicacionGuid", aplicacionGuid);

            var result = await cnn.QueryAsync<MensajeUsuarioEntity>("sp_ObtenerMensajesError", 
                                                                    param: parameters, 
                                                                    commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
