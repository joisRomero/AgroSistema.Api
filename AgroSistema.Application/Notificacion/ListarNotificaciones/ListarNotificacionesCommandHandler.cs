using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListarNotificacionesAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Notificacion.ListarNotificaciones
{
    public class ListarNotificacionesCommandHandler : IRequestHandler<ListarNotificacionesCommand, IEnumerable<ListarNotificacionesDTO>>
    {
        private readonly INotificacionRepository _notificacionRepository;
        private readonly IMapper _mapper;

        public ListarNotificacionesCommandHandler(INotificacionRepository notificacionRepository, IMapper mapper)
        {
            _notificacionRepository = notificacionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ListarNotificacionesDTO>> Handle(ListarNotificacionesCommand request, CancellationToken cancellationToken)
        {
            ListarNotificacionesRequestEntity entity = new()
            {
                IdUsuario = request.IdUsuario,
                IdCaso = request.IdCaso
            };

            var result = await _notificacionRepository.ListaNotificacionesAsync(entity);
            var response = _mapper.Map<IEnumerable<ListarNotificacionesDTO>>(result);

            return response;
        }
    }
}
