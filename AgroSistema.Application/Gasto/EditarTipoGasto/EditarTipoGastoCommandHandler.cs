using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EditarSociedadAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EditarTipoGasto
{
    public class EditarTipoGastoCommandHandler : IRequestHandler<EditarTipoGastoCommand>
    {
        private readonly IGastoRepository _gastoRepository;

        public EditarTipoGastoCommandHandler(IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<Unit> Handle(EditarTipoGastoCommand request, CancellationToken cancellationToken)
        {
            EditarTipoGastoEntity editarTipoGastoEntity = new()
            {
                IdTipoGasto = request.IdTipoGasto,
                NombreTipoGasto = request.NombreTipoGasto,
                Descripcion = request.Descripcion,
                UsuarioModifica = request.UsuarioModifica
            };

            await _gastoRepository.EditarTipoGasto(editarTipoGastoEntity);

            return Unit.Value;
        }
    }
}
