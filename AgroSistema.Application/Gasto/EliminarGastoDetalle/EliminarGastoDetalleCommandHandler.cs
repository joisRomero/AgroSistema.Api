using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EliminarGastoDetalle
{
    public class EliminarGastoDetalleCommandHandler : IRequestHandler<EliminarGastoDetalleCommand>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public EliminarGastoDetalleCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EliminarGastoDetalleCommand request, CancellationToken cancellationToken)
        {
            EliminarGastoDetalleEntity eliminarGastoDetalleEntity = new()
            {
                IdGastoDetalle = request.IdGastoDetalle,
                UsuarioElimina = request.UsuarioElimina
            };

            await _gastoRepository.EliminarGastoDetalle(eliminarGastoDetalleEntity);

            return Unit.Value;
        }
    }
}
