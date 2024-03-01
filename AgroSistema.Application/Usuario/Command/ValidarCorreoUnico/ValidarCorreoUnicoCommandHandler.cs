using AgroSistema.Application.Common.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarCorreoUnico
{
    public class ValidarCorreoUnicoCommandHandler : IRequestHandler<ValidarCorreoUnicoCommand, ValidarCorreoUnicoDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ValidarCorreoUnicoCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidarCorreoUnicoDTO> Handle(ValidarCorreoUnicoCommand request, CancellationToken cancellationToken)
        {
            var response = await _usuarioRepository.ValidarCorreoUnicoAsync(request.Correo);
            
            return new ValidarCorreoUnicoDTO { Respuesta = response };
        }
    }
}
