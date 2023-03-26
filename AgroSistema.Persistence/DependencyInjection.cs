using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Persistence.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace AgroSistema.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurePersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDataBase>(sp => new SqlDataBase(connectionString));
            services.AddTransient<IMensajeUsuarioRepository, MensajeUsuarioRepository>();
            services.AddTransient<ICultivoRepository, CultivoRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            return services;
        }
    }
}
