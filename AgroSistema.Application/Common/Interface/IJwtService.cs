using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface
{
    public interface IJwtService
    {
        string Generate(Claim[] claims, DateTime? expiresUtc = null, string audience = null);
    }
}
