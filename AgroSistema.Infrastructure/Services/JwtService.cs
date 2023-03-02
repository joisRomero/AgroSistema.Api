using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Settings;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AgroSistema.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;

        public JwtService(IOptions<JwtSettings> jwtSettings, IDateTimeService dateTimeService)
        {
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
        }

        public string Generate(Claim[] claims, DateTime? expiresUtc = null, string audience = null)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: audience,
                claims: claims,
                expires: expiresUtc ?? _dateTimeService.NowUtc.AddSeconds(_jwtSettings.ExpiresInSeconds),
                notBefore: _dateTimeService.NowUtc,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
