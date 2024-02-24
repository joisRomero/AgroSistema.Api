using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.RegistrarTipoActividadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.RegistrarTipoActividad
{
    public class RegistrarTipoActividadCommandHandler : IRequestHandler<RegistrarTipoActividadCommand>
    {
        private readonly ITipoActividad _tipoActividad;
        public RegistrarTipoActividadCommandHandler(ITipoActividad tipoActividad)
        {
            _tipoActividad = tipoActividad;
        }
        public async Task<Unit> Handle(RegistrarTipoActividadCommand request, CancellationToken cancellationToken)
        {
            RegistrarTipoActividadEntity registrarTipoActividadEntity = new()
            {
                NombreTipoActividad = request.NombreTipoActividad,
                RealizadaPorTipoActividad = request.RealizadaPorTipoActividad,
                DescripcionTipoActividad = request.DescripcionTipoActividad,
                IdUsuario = request.IdUsuario,
                UsuarioInserta = request.UsuarioInserta,
            };

            await _tipoActividad.RegistrarTipoActividadAsync(registrarTipoActividadEntity);

            return Unit.Value;
        }
    }
}
