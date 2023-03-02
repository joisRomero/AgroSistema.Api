using Microsoft.Extensions.Options;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Settings;
using System.Security.Claims;

namespace AgroSistema.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> settings)
        {
            Identifier = httpContextAccessor.HttpContext?.User?.FindFirstValue("identifier");
            Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Nombres = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.GivenName || c.Type == "nombres")?.Value;
            ApellidoPaterno = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.Surname || c.Type == "apellido_paterno")?.Value;
            ApellidoPaterno = httpContextAccessor.HttpContext?.User?.FindFirstValue("apellido_materno");
            Username = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "username")?.Value;
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            Telefono = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.HomePhone || c.Type == "telefono")?.Value;
            Celular = httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.MobilePhone || c.Type == "celular")?.Value;
            Rol = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            IsAuthenticated = Identifier != null;
            TraceIdentifier = httpContextAccessor.HttpContext?.TraceIdentifier;
        }

        public string Identifier { get; }
        public string Name { get; }
        public string Nombres { get; }
        public string ApellidoPaterno { get; }
        public string ApellidoMaterno { get; }
        public string Username { get; }
        public string Email { get; }
        public string Telefono { get; }
        public string Celular { get; }
        public string Rol { get; }
        public bool IsAuthenticated { get; }
        public string TraceIdentifier { get; }
    }
}
