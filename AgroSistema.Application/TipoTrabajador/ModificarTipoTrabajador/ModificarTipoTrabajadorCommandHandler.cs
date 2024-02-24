using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ModificarTipoTrabajadorAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ModificarTipoTrabajador
{
    public class ModificarTipoTrabajadorCommandHandler : IRequestHandler<ModificarTipoTrabajadorCommand>
    {
        private readonly ITipoTrabajador _tipoTrabajador;
        public ModificarTipoTrabajadorCommandHandler(ITipoTrabajador tipoTrabajador)
        {
            _tipoTrabajador = tipoTrabajador;
        }

        public async Task<Unit> Handle(ModificarTipoTrabajadorCommand request, CancellationToken cancellationToken)
        {
            ModificarTipoTrabajadorEntity entity = new()
            {
                IdTipoTrabajador = request.IdTipoTrabajador,
                NombreTipoTrabajador = request.NombreTipoTrabajador,
                DescripcionTipoTrabajador = request.DescripcionTipoTrabajador,
                UsuarioModifica = request.UsuarioModifica,
            };

            await _tipoTrabajador.ModificarTipoTrabajadorAsync(entity);

            return Unit.Value;
        }
    }
}
