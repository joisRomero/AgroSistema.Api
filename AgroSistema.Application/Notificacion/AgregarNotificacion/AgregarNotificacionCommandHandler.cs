using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarNotificacionAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Notificacion.AgregarNotificacion
{
    public class AgregarNotificacionCommandHandler : IRequestHandler<AgregarNotificacionCommand>
    {
        private readonly INotificacionRepository _notificacionRepository;

        public AgregarNotificacionCommandHandler(INotificacionRepository notificacionRepository)
        {
            _notificacionRepository = notificacionRepository;
        }

        public async Task<Unit> Handle(AgregarNotificacionCommand request, CancellationToken cancellationToken)
        {
            AgregarNotificacionEntity agregarNotificacionEntity = new()
            {
                IdUsuario = request.IdUsuario,
                Descripcion = request.Descripcion
            };

            await _notificacionRepository.AgregarNotificacion(agregarNotificacionEntity);

            return Unit.Value;
        }
    }
}
