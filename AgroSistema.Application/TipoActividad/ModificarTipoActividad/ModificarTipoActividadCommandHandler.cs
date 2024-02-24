using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ModificarTipoActividadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ModificarTipoActividad
{
    public class ModificarTipoActividadCommandHandler : IRequestHandler<ModificarTipoActividadCommand>
    {
        private readonly ITipoActividad _tipoActividad;
        public ModificarTipoActividadCommandHandler(ITipoActividad tipoActividad)
        {
            _tipoActividad = tipoActividad;
        }

        public async Task<Unit> Handle(ModificarTipoActividadCommand request, CancellationToken cancellationToken)
        {
            ModificarTipoActividadEntity modificarTipoActividadEntity = new()
            {
                IdTipoActividad = request.IdTipoActividad,
                NombreTipoActividad = request.NombreTipoActividad,
                DescripcionTipoActividad = request.DescripcionTipoActividad,
                RealizadaPorTipoActividad = request.RealizadaPorTipoActividad,
                UsuarioModifica = request.UsuarioModifica
            };

            await _tipoActividad.ModificarTipoActividadAsync(modificarTipoActividadEntity);

            return Unit.Value;
        }
    }
}
