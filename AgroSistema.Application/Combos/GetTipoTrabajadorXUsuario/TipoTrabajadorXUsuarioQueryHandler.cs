using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoTrabajadorXUsuario
{
    public class TipoTrabajadorXUsuarioQueryHandler : IRequestHandler<TipoTrabajadorXUsuarioQuery, IEnumerable<TipoTrabajadorXUsuarioDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public TipoTrabajadorXUsuarioQueryHandler(ICombosRepository combosRepository,IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TipoTrabajadorXUsuarioDTO>> Handle(TipoTrabajadorXUsuarioQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetTipoTrabajadorXUsuarioAsync(request.IdUsuario);

            return _mapper.Map<IEnumerable<TipoTrabajadorXUsuarioDTO>>(response);
        }
    }
}
