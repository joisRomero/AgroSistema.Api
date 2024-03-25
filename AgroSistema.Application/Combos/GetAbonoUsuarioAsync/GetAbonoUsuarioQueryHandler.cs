using AgroSistema.Application.Combos.GetUnidadFumigacion;
using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAbonoUsuarioAsync
{
    public class GetAbonoUsuarioQueryHandler : IRequestHandler<GetAbonoUsuarioQuery, IEnumerable<GetAbonoUsuarioQueryDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public GetAbonoUsuarioQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAbonoUsuarioQueryDTO>> Handle(GetAbonoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetAbonoUsuarioAsync(request.IdUsuario);
            return _mapper.Map<IEnumerable<GetAbonoUsuarioQueryDTO>>(response);
        }
    }
}
