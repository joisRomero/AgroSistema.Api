using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.RegistrarInvitacionSociedadAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.RegistrarInvitacionSociedadAsync
{
    public class RegistrarInvitacionSociedadCommandHandler : IRequestHandler<RegistrarInvitacionSociedadCommand>
    {
        private readonly IInvitacionRepository _invitacionRepository;
        private readonly ILogger<AgregarCultivoCommandHandler> _logger;

        public RegistrarInvitacionSociedadCommandHandler(IInvitacionRepository invitacionRepository,ILogger<AgregarCultivoCommandHandler> logger)
        {
            _invitacionRepository = invitacionRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(RegistrarInvitacionSociedadCommand request, CancellationToken cancellationToken)
        {
            RegistrarInvitacionSociedadEntity entity = new()
            {
                IdEmisor = request.IdEmisor,
                IdReceptor = request.IdReceptor,
                IdSociedad = request.IdSociedad,
                UsuarioInserta = request.UsuarioInserta

            };

            await _invitacionRepository.RegistrarInvitacionSociedadAsync(entity);
            return Unit.Value;
        }
    }
}
