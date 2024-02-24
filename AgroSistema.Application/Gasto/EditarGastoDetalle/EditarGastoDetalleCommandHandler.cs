using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EditarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EditarGastoDetalle
{
    public class EditarGastoDetalleCommandHandler : IRequestHandler<EditarGastoDetalleCommand>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public EditarGastoDetalleCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditarGastoDetalleCommand request, CancellationToken cancellationToken)
        {
            EditarGastoDetalleEntity editarGastoDetalleEntity = new()
            {
                IdGastoDetalle = request.IdGastoDetalle,
                IdTipoGasto = request.IdTipoGasto,
                FechaGasto = request.FechaGasto,
                Cantidad = request.Cantidad,
                CostoUnitario = request.CostoUnitario,
                CostoTotal = request.CostoTotal,
                Descripcion = request.Descripcion,
                UsuarioModifica = request.UsuarioModifica
            };

            await _gastoRepository.EditarGastoDetalle(editarGastoDetalleEntity);

            return Unit.Value;
        }
    }
}
