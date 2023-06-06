using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetCalidadesCosecha
{
    public class GetCalidadesCosechaQueryHandler : IRequestHandler<GetCalidadesCosechaQuery, IEnumerable<GetCalidadesCosechaDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;

        public GetCalidadesCosechaQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetCalidadesCosechaDTO>> Handle(GetCalidadesCosechaQuery request, CancellationToken cancellationToken)
        {
            var result = await _combosRepository.GetCalidadesCosechaAsync();
            return _mapper.Map<IEnumerable<GetCalidadesCosechaDTO>>(result);
        }
    }
}
