using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Usuario.Command.CrearUsuario;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.CambiarClaveRecuperacionCuenta
{
    public class CambiarClaveRecuperacionCuentaQueryHandler : IRequestHandler<CambiarClaveRecuperacionCuentaQuery, CambiarClaveRecuperacionCuentaDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ICryptography _cryptography;

        public CambiarClaveRecuperacionCuentaQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper, ICryptography cryptography)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _cryptography = cryptography;

        }
        public async Task<CambiarClaveRecuperacionCuentaDTO> Handle(CambiarClaveRecuperacionCuentaQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioRepository.CambiarClaveRecuperacionCuenta(_cryptography.Encrypt(request.Clave), request.Correo);

            return _mapper.Map<CambiarClaveRecuperacionCuentaDTO>(result);
        }
    }
}
