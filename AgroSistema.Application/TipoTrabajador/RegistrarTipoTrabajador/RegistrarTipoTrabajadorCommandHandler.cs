using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.RegistrarTipoTrabajadorAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.RegistrarTipoTrabajador
{
    public class RegistrarTipoTrabajadorCommandHandler : IRequestHandler<RegistrarTipoTrabajadorCommand>
    {
        private readonly ITipoTrabajador _tipoTrabajador;
        public RegistrarTipoTrabajadorCommandHandler(ITipoTrabajador tipoTrabajador)
        {
            _tipoTrabajador = tipoTrabajador;
        }
        public async Task<Unit> Handle(RegistrarTipoTrabajadorCommand request, CancellationToken cancellationToken)
        {
            RegistrarTipoTrabajadorEntity entity = new()
            {
                NombreTipoTrabajador = request.NombreTipoTrabajador,
                DescripcionTipoTrabajador = request.DescripcionTipoTrabajador,
                UsuarioInserta = request.UsuarioInserta
            };

            await _tipoTrabajador.RegistrarTipoTrabajadorAsync(entity);

            return Unit.Value;
        }
    }
}
