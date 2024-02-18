using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ValidarCodigoRecuperacionCuentaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarCodigoRecuperacionCuenta
{
    public class ValidarCodigoRecuperacionCuentaCommandHandler : IRequestHandler<ValidarCodigoRecuperacionCuentaCommand>
    {
        private IUsuarioRepository _usuarioRepository;
        public ValidarCodigoRecuperacionCuentaCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Unit> Handle(ValidarCodigoRecuperacionCuentaCommand request, CancellationToken cancellationToken)
        {
            ValidarTokenRecoveryAcountEntity entity = new() { 
                Correo = request.Correo,
                Token = request.Token,
            };

            var result = await _usuarioRepository.ValidarCodigoRecuperacionCuenta(entity);
            if (result)
            {
                return Unit.Value;
            }
            else
            {
                throw new BadRequestException(new MensajeUsuarioDTO() { Descripcion = "El código no es válido." });
            }
            
        }
    }
}
