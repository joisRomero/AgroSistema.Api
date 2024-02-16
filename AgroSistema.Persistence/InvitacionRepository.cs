using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
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
    public class InvitacionRepository : IInvitacionRepository
    {
        private readonly IDataBase _database;
        public InvitacionRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ListarInvitacionesSociedadEntity>> ListarInvitacionesSociedadAsync(RequestListarInvitacionesSociedadEntity requestListarInvitacionesSociedadEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario", requestListarInvitacionesSociedadEntity.IdUsuario);

            var result = await cnn.QueryAsync<ListarInvitacionesSociedadEntity>("sp_ListarInvitacionesSociedad", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
