using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetTipoGasto
{
    public class ObtenerTipoGastoCommandHandler : IRequestHandler<ObtenerTipoGastoCommand, ObtenerTipoGastoDTO>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public ObtenerTipoGastoCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerTipoGastoDTO> Handle(ObtenerTipoGastoCommand request, CancellationToken cancellationToken)
        {
           
            var result = await _gastoRepository.GetTipoGastoPorIdAsync(request.IdTipoGasto);

            return _mapper.Map<ObtenerTipoGastoDTO>(result);
        }
    }
}
