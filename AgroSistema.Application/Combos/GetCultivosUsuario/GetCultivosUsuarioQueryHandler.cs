using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetCultivosUsuario
{
    public class GetCultivosUsuarioQueryHandler : IRequestHandler<GetCultivosUsuarioQuery, IEnumerable<GetCultivosUsuarioDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public GetCultivosUsuarioQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCultivosUsuarioDTO>> Handle(GetCultivosUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _combosRepository.GetCultivosUsuarioAsync(request.IdUsuario);
            return _mapper.Map<IEnumerable<GetCultivosUsuarioDTO>>(result);
        }
    }
}
