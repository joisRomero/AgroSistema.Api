using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadesCosecha
{
    public class GetUnidadesCosechaQueryHandler : IRequestHandler<GetUnidadesCosechaQuery, IEnumerable<GetUnidadesCosechaDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public GetUnidadesCosechaQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUnidadesCosechaDTO>> Handle(GetUnidadesCosechaQuery request, CancellationToken cancellationToken)
        {
            var result = await _combosRepository.GetUnidadesCosechaAsync();
            return _mapper.Map<IEnumerable<GetUnidadesCosechaDTO>>(result);
        }
    }
}
