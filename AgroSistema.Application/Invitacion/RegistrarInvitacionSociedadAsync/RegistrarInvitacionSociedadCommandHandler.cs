using AgroSistema.Application.Common.Hub;
using AgroSistema.Application.Common.Interface.Hub;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.RegistrarInvitacionSociedadAsync;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.RegistrarInvitacionSociedadAsync
{
    public class RegistrarInvitacionSociedadCommandHandler : IRequestHandler<RegistrarInvitacionSociedadCommand>
    {
        private readonly IInvitacionRepository _invitacionRepository;
        private readonly IMapper _mapper;
        private IHubContext<InvitacionHub, IInvitacionHub> _hubContext;

        public RegistrarInvitacionSociedadCommandHandler(IInvitacionRepository invitacionRepository, IMapper mapper, IHubContext<InvitacionHub, IInvitacionHub> hubContext)
        {
            _invitacionRepository = invitacionRepository;
            _mapper = mapper;
            _hubContext = hubContext;
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

            var entityListarInvitaciones = new RequestListarInvitacionesSociedadEntity()
            {
                IdUsuario = request.IdReceptor
            };

            var resultListaInvitacion = await _invitacionRepository.ListarInvitacionesSociedadAsync(entityListarInvitaciones);

            var responseListaInvitacion = _mapper.Map<IEnumerable<ListarInvitacionesSociedadDTO>>(resultListaInvitacion);

            await _hubContext.Clients.All.EnviarNotificacionInvitacion(responseListaInvitacion);

            return Unit.Value;
        }
    }
}
