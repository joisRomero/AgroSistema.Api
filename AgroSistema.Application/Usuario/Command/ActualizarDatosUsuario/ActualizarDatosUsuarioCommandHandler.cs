using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Interface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroSistema.Domain.Entities.ActualizarDatosUsuario;

namespace AgroSistema.Application.Usuario.Command.ActualizarDatosUsuario
{
    public class ActualizarDatosUsuarioCommandHandler : IRequestHandler<ActualizarDatosUsuarioCommand, ActualizarDatosUsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public ActualizarDatosUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<ActualizarDatosUsuarioDTO> Handle(ActualizarDatosUsuarioCommand request, CancellationToken cancellationToken)
        {
            var actualizarDatosUsaurio = new ActualizarDatosUsuarioEntity()
            { 
                Id = request.Id,
                ApellidoMaterno = request.ApellidoMaterno,
                ApellidoPaterno = request.ApellidoPaterno,
                Correo = request.Correo,
                Nombre = request.Nombre,
            };

            var result = await _usuarioRepository.ActualizarDatosUsuario(actualizarDatosUsaurio);
            return _mapper.Map<ActualizarDatosUsuarioDTO>(result);
        }
    }
}
