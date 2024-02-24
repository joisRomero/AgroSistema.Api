using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarGastoDetalleAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.AgregarGastoDetalle
{
    public class AgregarGastoDetalleCommandHandler : IRequestHandler<AgregarGastoDetalleCommand>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public AgregarGastoDetalleCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AgregarGastoDetalleCommand request, CancellationToken cancellationToken)
        {
            AgregarGastoDetalleEntity agregarGastoDetalleEntity = new()
            {
                IdCampania = request.IdCampania,
                IdTipoGasto = request.IdTipoGasto,
                FechaGasto = request.FechaGasto,
                Cantidad = request.Cantidad,
                CostoUnitario = request.CostoUnitario,
                CostoTotal = request.CostoTotal,
                Descripcion = request.Descripcion,
                UsuarioInserta = request.UsuarioInserta
            };

            await _gastoRepository.AgregarGastoDetalle(agregarGastoDetalleEntity);

            return Unit.Value;
        }
    }
}
