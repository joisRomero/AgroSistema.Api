using AgroSistema.Api.Middlewares;

namespace AgroSistema.Api.Extensions
{
    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>(env);
        }
    }
}
