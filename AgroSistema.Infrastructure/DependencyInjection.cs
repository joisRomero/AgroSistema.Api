using AgroSistema.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;


namespace AgroSistema.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IReporteExcel, ReporteExcel>();
            services.AddSingleton<ICryptography, AsEncryption>();
            services.AddSingleton<IReportePDF, ReportePdf>();
            services.AddTransient<IJwtService, JwtService>();
            return services;
        }
    }
}
