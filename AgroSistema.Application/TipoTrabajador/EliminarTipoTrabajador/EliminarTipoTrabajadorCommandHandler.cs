using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarTipoTrabjadorAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.EliminarTipoTrabajador
{
    public class EliminarTipoTrabajadorCommandHandler : IRequestHandler<EliminarTipoTrabajadorCommand>
    {
        private readonly ITipoTrabajador _tipoTrabajador;
        public EliminarTipoTrabajadorCommandHandler(ITipoTrabajador tipoTrabajador)
        {
            _tipoTrabajador = tipoTrabajador;
        }

        public async Task<Unit> Handle(EliminarTipoTrabajadorCommand request, CancellationToken cancellationToken)
        {
            EliminarTipoTrabajadorEntity eliminarTipoTrabajadorEntity = new()
            {
                IdTipoTrabajador = request.IdTipoTrabajador,
                UsuarioElimina = request.UsuarioElimina
            };

            await _tipoTrabajador.EliminarTipoTrabjadorAsync(eliminarTipoTrabajadorEntity);
            return Unit.Value;
        }
    }
}
