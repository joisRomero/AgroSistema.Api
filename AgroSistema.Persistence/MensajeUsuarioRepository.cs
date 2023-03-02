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

            //using var reader = await cnn.ExecuteReaderAsync(
            //    "sp_MensajeUsuario_GetListaError",
            //    param: parameters,
            //    commandType: CommandType.StoredProcedure);

            //var result = new List<MensajeUsuarioEntity>();

            //while (reader.Read())
            //{
            //    var entity = new MensajeUsuarioEntity
            //    {
            //        Id = reader.IsDBNull(reader.GetOrdinal("MensajeUsuarioID")) ? default : reader.GetInt32(reader.GetOrdinal("MensajeUsuarioID")).ToString(),
            //        Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetString(reader.GetOrdinal("Codigo")),
            //        AplicacionGuid = reader.IsDBNull(reader.GetOrdinal("AplicacionGuid")) ? default : reader.GetGuid(reader.GetOrdinal("AplicacionGuid")),
            //        Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? default : reader.GetString(reader.GetOrdinal("Descripcion")),
            //    };
            //    result.Add(entity);
            //}

            var result = await cnn.QueryAsync<MensajeUsuarioEntity>("sp_MensajeUsuario_GetListaError", param: parameters, 
                                                                    commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
