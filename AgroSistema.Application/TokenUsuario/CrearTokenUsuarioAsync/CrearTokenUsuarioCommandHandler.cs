using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Settings;
using AgroSistema.Application.Login;
using AgroSistema.Domain.Entities.CrearTokenUsuarioAsync;
using AgroSistema.Domain.Entities.LoginAsync;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AgroSistema.Application.TokenUsuario.CrearTokenUsuarioAsync
{
    public class CrearTokenUsuarioCommandHandler : IRequestHandler<CrearTokenUsuarioCommand, CrearTokenUsuarioDTO>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IEnumerable<MensajeUsuarioDTO> _mensajesUsuario;
        private readonly ITokenRepository _tokenRepository;
        private readonly IJwtService _jwtService;
        private readonly IDateTimeService _dateTimeService;
        private readonly ILoginRepository _loginRepository;
        private readonly ICryptography _cryptography;
        private readonly AppSettings _appSettings;

        public CrearTokenUsuarioCommandHandler(IMemoryCache memoryCache, IOptions<JwtSettings> jwtSettings, 
            ITokenRepository tokenRepository, IJwtService jwtService, IDateTimeService dateTimeService, 
            ILoginRepository loginRepository, ICryptography cryptography, IOptions<AppSettings> appSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _mensajesUsuario = memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey);
            _tokenRepository = tokenRepository;
            _jwtService = jwtService;
            _dateTimeService = dateTimeService;
            _loginRepository = loginRepository;
            _cryptography = cryptography;
            _appSettings = appSettings.Value;
        }

        public async Task<CrearTokenUsuarioDTO> Handle(CrearTokenUsuarioCommand request, CancellationToken cancellationToken)
        {
            LoginDTO login = new LoginDTO();
            string? sClave = string.Empty;

            var claveBinary = System.Convert.FromBase64String(request.Clave);
            var claveString = System.Text.Encoding.UTF8.GetString(claveBinary);

            var usuarioBinary = System.Convert.FromBase64String(request.Usuario);
            var usuarioString = System.Text.Encoding.UTF8.GetString(usuarioBinary);

            if (!string.IsNullOrEmpty(claveString))
            {
                sClave = _cryptography.Encrypt(claveString);
            }

            int respuesta = await _loginRepository.ValidarUsuarioAsync(request.Usuario, sClave);

            if (respuesta == 1)
            {
                var listaAudiencias = new List<string>
                {
                    _appSettings.ApplicationName
                };

                var usuarioEntity = await _loginRepository.ObtenerUsuarioAsync(usuarioString, sClave);
                var crearTokenUsuarioDTO = new CrearTokenUsuarioDTO();
                var accesToken = await GenerateToken(usuarioEntity, _dateTimeService.NowUtc.AddSeconds(_jwtSettings.ExpiresInSeconds), listaAudiencias);
                var expiresIn = _jwtSettings.ExpiresInSeconds;
                var TokenType = _jwtSettings.TokenType;

                crearTokenUsuarioDTO.AccessToken = accesToken;
                crearTokenUsuarioDTO.ExpiresIn = expiresIn;
                crearTokenUsuarioDTO.TokenType = TokenType;

                return crearTokenUsuarioDTO;
            }
            else
            {
                throw new BadRequestException(_mensajesUsuario.FirstOrDefault(m => m.Codigo == "000007"));
            }
        }

        private async Task<string> GenerateToken(LoginEntity loginEntity, DateTime expiresUtc, List<string> listaAudiencias)
        {
            var claims = new List<Claim>
            {
                new Claim("identifier", loginEntity.IdUsuario ?? "")
            };

            foreach (var auienciad in listaAudiencias)
            {
                claims.Add(new Claim("aud", auienciad ?? ""));
            }

            var token = _jwtService.Generate(claims.ToArray(), expiresUtc);

             var crearTokenUsuarioEntity = new CrearTokenUsuarioEntity
            {
                Identificador = Guid.NewGuid(),
                Owner = loginEntity.IdUsuario,
                Tipo = _jwtSettings.TokenType,
                Valor = token,
                FechaExpiracion = expiresUtc
            };

            //await _tokenRepository.CrearTokenUsuarioAsync(crearTokenUsuarioEntity);

            return token;
        }
    }
}
