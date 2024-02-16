using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.CambiarEstadoInvitacionAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.CambiarEstadoInvitacionSociedadAsync
{
    public class CambiarEstadoInvitacionSociedadCommandHandler : IRequestHandler<CambiarEstadoInvitacionSociedadCommand>
    {
        private readonly IInvitacionRepository _invitacionRepository;
        private readonly ILogger<AgregarCultivoCommandHandler> _logger;

        public CambiarEstadoInvitacionSociedadCommandHandler(IInvitacionRepository invitacionRepository, ILogger<AgregarCultivoCommandHandler> logger)
        {
            _invitacionRepository = invitacionRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CambiarEstadoInvitacionSociedadCommand request, CancellationToken cancellationToken)
        {
            CambiarEstadoInvitacionEntity cambiarEstadoInvitacionEntity = new()
            {
                IdInvitacion = request.IdInvitacion,
                Accion = request.Accion,
                UsuarioModifica = request.UsuarioModifica
            };

            await _invitacionRepository.CambiarEstadoInvitacionAsync(cambiarEstadoInvitacionEntity);
            return Unit.Value;
        }
    }
}
