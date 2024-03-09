using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Settings;
using AgroSistema.Application;
using AgroSistema.Infrastructure;
using AgroSistema.Persistence;
using AgroSistema.Api.Utils;
using System.IdentityModel.Tokens.Jwt;
using FluentValidation.AspNetCore;
using AgroSistema.Api.Services;

namespace AgroSistema.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>();
            var jwtSettings = configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();

            if (jwtSettings.Enabled)
            {
                services.AddAuthentication(config =>
                {
                    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(config =>
               {
                   config.RequireHttpsMetadata = false;
                   config.SaveToken = true;
                   config.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = false,
                       RequireSignedTokens = true,
                       ValidateIssuer = true,
                       ValidIssuer = jwtSettings.Issuer,
                       ValidateAudience = jwtSettings.ValidateAudience,
                       ValidAudience = appSettings.ApplicationName,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                       {
                           var jwt = new JwtSecurityToken(token);
                           return jwt;
                       }
                   };
               });
            }

            return services;
        }

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();

            services.AddAuthorization(c =>
            {
                if (jwtSettings.Enabled)
                {
                    c.AddPolicy(Constants.GlobalOAuthPolicyName, p =>
                    {
                        p.RequireAuthenticatedUser();
                    });
                }
            });

            return services;
        }

        public static IServiceCollection AddCustomMVC(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(Constants.JwtSettings).Get<JwtSettings>();

            services.AddMemoryCache();
            services.AddControllers(options =>
            {
                if (jwtSettings.Enabled)
                {
                    options.Filters.Add(new AuthorizeFilter(Constants.GlobalOAuthPolicyName));
                }
            })
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ICurrentUser>());
            services.AddCors(options =>
            {
                options.AddPolicy(Constants.CorsPolicyName,
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("Content-Disposition"));
            });
            services.AddHttpContextAccessor();
            services.AddResponseCompression();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUser, CurrentUser>();
            return services;
        }

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.Configure<JwtSettings>(configuration.GetSection(Constants.JwtSettings));
            services.Configure<CredencialesCorreo>(configuration.GetSection(Constants.CredencialesCorreo));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IServiceCollection AddLayersDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.ConnectionStringSqlServer);
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();
            services.AddInfrastructurePersistenceLayer(connectionString);
            return services;
        }
    }
}
