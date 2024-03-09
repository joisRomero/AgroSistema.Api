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
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ISociedadRepository, SociedadRepository>();
            services.AddTransient<ICampaniaRepository, CampaniaRepository>();
            services.AddTransient<ICosechaRepository, CosechaRepository>();
            services.AddTransient<ICombosRepository, CombosRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IInvitacionRepository, InvitacionRepository>();
            services.AddTransient<ITipoTrabajador, TipoTrabajadorRepository>();
            services.AddTransient<ITipoActividad, TipoActividadRepository>();
            services.AddTransient<IGastoRepository, GastoRepository>();
            services.AddTransient<IActividadRepository, ActividadRepository>();
            services.AddTransient<INotificacionRepository, NotificacionRepository>();
            return services;
        }
    }
}
