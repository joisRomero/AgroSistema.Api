using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarSociedadAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EliminarTipoGasto
{
    public class EliminarTipoGastoCommandHandler : IRequestHandler<EliminarTipoGastoCommand>
    {
        private readonly IGastoRepository _gastoRepository;

        public EliminarTipoGastoCommandHandler(IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }
        public async Task<Unit> Handle(EliminarTipoGastoCommand request, CancellationToken cancellationToken)
        {
            EliminarTipoGastoEntity eliminarTipoGastoEntity = new()
            {
                IdTipoGasto = request.IdTipoGasto,
                UsuarioElimina = request.UsuarioElimina,
            };

            await _gastoRepository.EliminarTipoGasto(eliminarTipoGastoEntity);

            return Unit.Value;
        }
    }
}
