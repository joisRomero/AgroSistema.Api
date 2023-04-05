using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.LoginAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace AgroSistema.Persistence
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDataBase _database;
        public LoginRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<LoginEntity> ObtenerUsuarioAsync(string usuario, string clave)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pClave", clave);

            LoginEntity result = new();
            var response = await cnn.QueryAsync<LoginEntity>("sp_ObtenerUsuarioLogin", parameters, 
                                                              commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }

        public async Task<int> ValidarUsuarioAsync(string usuario, string clave)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pClave", clave);

            int result = 0;
            var response = await cnn.QueryAsync<int>("sp_ValidarUsuarioLogin", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }
    }
}
