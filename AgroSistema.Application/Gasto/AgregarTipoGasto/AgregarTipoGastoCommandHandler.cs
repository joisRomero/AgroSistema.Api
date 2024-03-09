using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.AgregarTipoGasto
{
    public class AgregarTipoGastoCommandHandler : IRequestHandler<AgregarTipoGastoCommand>
    {
        private readonly IGastoRepository _gastoRepository;

        public AgregarTipoGastoCommandHandler(IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<Unit> Handle(AgregarTipoGastoCommand request, CancellationToken cancellationToken)
        {
            AgregarTipoGastoEntity agregarTipoGastoEntity = new()
            {
                NombreTipoGasto = request.NombreTipoGasto,
                Descripcion = request.Descripcion,
                UsuarioInserta = request.UsuarioInserta,
                IdUsuario = request.IdUsuario
            };

            await _gastoRepository.AgregarTipoGasto(agregarTipoGastoEntity);
            return Unit.Value;
        }
    }
}
