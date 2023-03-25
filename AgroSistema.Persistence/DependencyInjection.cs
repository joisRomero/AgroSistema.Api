using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroSistema.Persistence.DataBase;

namespace AgroSistema.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurePersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDataBase>(sp => new SqlDataBase(connectionString));
            services.AddTransient<IMensajeUsuarioRepository, MensajeUsuarioRepository>();
            services.AddTransient<ICultivoRepository, CultivoRepository>();

            return services;
        }
    }
}
