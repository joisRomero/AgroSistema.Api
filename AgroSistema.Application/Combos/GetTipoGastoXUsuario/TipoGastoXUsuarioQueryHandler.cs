using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetTipoGastoXUsuarioAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoGastoXUsuario
{
    public class TipoGastoXUsuarioQueryHandler : IRequestHandler<TipoGastoXUsuarioQuery, IEnumerable<TipoGastoXUsuarioDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public TipoGastoXUsuarioQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TipoGastoXUsuarioDTO>> Handle(TipoGastoXUsuarioQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetTipoGastoXUsuarioAsync(request.IdUsuario);

            return _mapper.Map<IEnumerable<TipoGastoXUsuarioDTO>>(response);
        }
    }
}
