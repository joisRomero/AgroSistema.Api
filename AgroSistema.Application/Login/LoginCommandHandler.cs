using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Settings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace AgroSistema.Application.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;
        private readonly IEnumerable<MensajeUsuarioDTO> _mensajesUsuario;
        private readonly ICryptography _cryptography;

        public LoginCommandHandler(IMapper mapper, ILoginRepository loginRepository, IMemoryCache memoryCache, ICryptography cryptography)
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
            _mensajesUsuario = memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey);
            _cryptography = cryptography;
        }
        public async Task<LoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginDTO login = new();
            string? sClave = string.Empty;

            var claveBinary = System.Convert.FromBase64String(request.Clave);
            var claveString = System.Text.Encoding.UTF8.GetString(claveBinary);

            var usuarioBinary = System.Convert.FromBase64String(request.Usuario);
            var usuarioString = System.Text.Encoding.UTF8.GetString(usuarioBinary);

            if (!string.IsNullOrEmpty(claveString))
            {
                sClave = _cryptography.Encrypt(claveString);
            }

            int respuesta = await _loginRepository.ValidarUsuarioAsync(usuarioString, sClave);
            if (respuesta == 0)
            {
                throw new BadRequestException(_mensajesUsuario.FirstOrDefault(m => m.Codigo == "000007"));                
            }

            var result = await _loginRepository.ObtenerUsuarioAsync(usuarioString, sClave);

            return _mapper.Map<LoginDTO>(result);

        }
    }
}
