using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadFumigacion
{
    public class UnidadFumigacionQueryHandler : IRequestHandler<UnidadFumigacionQuery, IEnumerable<UnidadFumigacionDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public UnidadFumigacionQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UnidadFumigacionDTO>> Handle(UnidadFumigacionQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetUnidadFumigacionAsync();

            return _mapper.Map<IEnumerable<UnidadFumigacionDTO>>(response);
        }
    }
}
