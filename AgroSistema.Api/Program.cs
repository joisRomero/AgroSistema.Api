using Serilog;
using Autofac.Extensions.DependencyInjection;
using AgroSistema.Api;
using AgroSistema.Api.Utils;

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Constants.JsonFilePath, false, true)
                .AddJsonFile(string.Format(Constants.JsonEnviromentFilePath, Environment.GetEnvironmentVariable(Constants.EnviromentVariable)), true, true)
                .AddEnvironmentVariables()
                .Build();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


try
{
    Log.Information(Constants.StarAppMessage);
    Log.Information(Constants.ConfigAppMessge);

    var builder = WebApplication.CreateBuilder(args);


    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).
    ConfigureHostConfiguration(configHost =>
    {
        configHost.AddConfiguration(configuration);
    }).UseSerilog();


    var startUp = new StartUp(builder.Configuration);
    startUp.ConfigureServices(builder.Services);

    var app = builder.Build();

    startUp.Configure(app, builder.Environment, builder.Configuration);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, Constants.EndingAppMessage);
    Log.Fatal(Constants.EndAppMessage);
    throw;
}
finally
{
    Log.CloseAndFlush();
}



