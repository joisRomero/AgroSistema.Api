using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAgroquimicoUsuarioAsync
{
    public class GetAgroquimicoUsuarioQueryHandler : IRequestHandler<GetAgroquimicoUsuarioQuery, IEnumerable<GetAgroquimicoUsuarioDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public GetAgroquimicoUsuarioQueryHandler(ICombosRepository combosRepository , IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAgroquimicoUsuarioDTO>> Handle(GetAgroquimicoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetAgroquimicoUsuarioAsync(request.IdUsuario);
            return _mapper.Map<IEnumerable<GetAgroquimicoUsuarioDTO>>(response);
        }
    }
}
