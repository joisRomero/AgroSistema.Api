using AgroSistema.Api.Extensions;
using AgroSistema.Api.Utils;
using AgroSistema.Application.Common.Hub;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

namespace AgroSistema.Api
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomAuthentication(Configuration);
            services.AddCustomAuthorization(Configuration);
            services.AddCustomMVC(Configuration);
            services.AddCustomServices();
            services.AddCustomHealthCheck();
            services.AddCustomOptions(Configuration);
            services.AddLayersDependencyInjections(Configuration);
            services.AddSignalR();

            var container = new ContainerBuilder();
            container.Populate(services);

            ApplicationContainer = container.Build();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConfigurationManager configurationManager)
        {
            app.UseSerilogRequestLogging();
            app.UseResponseCompression();
            app.UseCustomExceptionHandler(env);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(Constants.CorsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            var applicationDisplayName = configurationManager.GetValue<string>(Constants.ApplicationDisplayName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapGet(Constants.WelcomePath, async context =>
                {
                    await context.Response.WriteAsync(string.Format(Constants.WelcomeAPI,
                        applicationDisplayName));
                });
                endpoints.MapHealthChecks(Constants.HealthPath, new HealthCheckOptions()
                {
                    AllowCachingResponses = false
                });
                endpoints.MapHub<InvitacionHub>("/hubs/invitaciones");
            });

            

        }
    }
}
