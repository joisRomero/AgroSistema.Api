using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarTipoActividadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.EliminarTipoActividad
{
    public class EliminarTipoActividadCommandHandler : IRequestHandler<EliminarTipoActividadCommand>
    {
        private readonly ITipoActividad _tipoActividad;
        public EliminarTipoActividadCommandHandler(ITipoActividad tipoActividad)
        {
            _tipoActividad = tipoActividad;
        }

        public async Task<Unit> Handle(EliminarTipoActividadCommand request, CancellationToken cancellationToken)
        {
            EliminarTipoActividadEntity eliminarTipoActividadEntity = new()
            {
                IdTipoActividad = request.IdTipoActividad,
                UsuarioElimina = request.UsuarioElimina,
            };

            await _tipoActividad.EliminarTipoActividadAsync(eliminarTipoActividadEntity);

            return Unit.Value;
        }
    }
}
