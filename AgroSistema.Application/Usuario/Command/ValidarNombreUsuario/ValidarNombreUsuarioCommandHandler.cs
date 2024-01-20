using AgroSistema.Application.Common.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarUsuario
{
    public class ValidarNombreUsuarioCommandHandler : IRequestHandler<ValidarNombreUsuarioCommand, ValidarNombreUsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ValidarNombreUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidarNombreUsuarioDTO> Handle(ValidarNombreUsuarioCommand request, CancellationToken cancellationToken)
        {
            var respose = await _usuarioRepository.ValidarUsuario(request.NombreUsuario);

            return new ValidarNombreUsuarioDTO { Respuesta = respose };
        }
    }
}
