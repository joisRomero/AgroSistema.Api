using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.CrearUsuarioAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.CrearUsuario
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, CrearUsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICryptography _cryptography;
        private readonly IMapper _mapper;
        public CrearUsuarioCommandHandler(IUsuarioRepository usuarioRepository, ICryptography cryptography, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _cryptography = cryptography;
            _mapper = mapper;
        }
        public async Task<CrearUsuarioDTO> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            string clave = _cryptography.Encrypt(request.Clave);

            var crearUsuarioEntity = new CrearUsuarioEntity() { 
                Nombre = request.Nombre,
                Clave = clave,
                NombreUsuario = request.NombreUsuario,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Correo = request.Correo 
            };

            var respose = await _usuarioRepository.CrearUsuario(crearUsuarioEntity);

            return _mapper.Map<CrearUsuarioDTO>(respose);
        }
    }
}
