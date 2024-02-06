using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ActualizarClavesUsuario
{
    public class ActualizarClavesUsuarioCommandHandler : IRequestHandler<ActualizarClavesUsuarioCommand, ActualizarClavesUsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ICryptography _cryptography;
        public ActualizarClavesUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper, ICryptography cryptography)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _cryptography = cryptography;
        }
        public async Task<ActualizarClavesUsuarioDTO> Handle(ActualizarClavesUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validacion = await _usuarioRepository.ValidarClaveActual(_cryptography.Encrypt(request.ClaveActual), request.IdUsuario);
            if (validacion == 0)
            {
                throw new BadRequestException(new MensajeUsuarioDTO() { Descripcion = "La clave actual no es la correcta. Vuelva a intentarlo."});
            }
            var result = await _usuarioRepository.ActualizarClavesUsuario(_cryptography.Encrypt(request.ClaveNueva), request.IdUsuario);

            return new ActualizarClavesUsuarioDTO() { Id = result };
        }
    }
}
