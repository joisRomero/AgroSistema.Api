using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetGastoDetallePorId
{
    public class ObtenerGastoDetalleCommandHandler : IRequestHandler<ObtenerGastoDetalleCommand, ObtenerGastoDetalleDTO>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public ObtenerGastoDetalleCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerGastoDetalleDTO> Handle(ObtenerGastoDetalleCommand request, CancellationToken cancellationToken)
        {
            var result = await _gastoRepository.GetGastoDetallePorIdAsync(request.IdGastoDetalle);

            return _mapper.Map<ObtenerGastoDetalleDTO>(result);
        }
    }
}
