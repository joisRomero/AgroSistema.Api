using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoActividadXUsuario
{
    public class TipoActividadXUsuarioQueryHandler : IRequestHandler<TipoActividadXUsuarioQuery, IEnumerable<TipoActividadXUsuarioDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public TipoActividadXUsuarioQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TipoActividadXUsuarioDTO>> Handle(TipoActividadXUsuarioQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetTipoActividadXUsuarioAsync(request.IdUsuario);

            return _mapper.Map<IEnumerable<TipoActividadXUsuarioDTO>>(response);
        }
    }
}
