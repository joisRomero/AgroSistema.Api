using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetUnidadesCampaniaAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadesCampania
{
    public class GetUnidadesCampaniaQueryHandler : IRequestHandler<GetUnidadesCampaniaQuery, IEnumerable<GetUnidadesCampaniaDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public GetUnidadesCampaniaQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUnidadesCampaniaDTO>> Handle(GetUnidadesCampaniaQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UnidadesCampaniaEntity> result = await _combosRepository.GetUnidadesCampaniaAsync();
            return _mapper.Map<IEnumerable<GetUnidadesCampaniaDTO>>(result);
        }
    }
}
