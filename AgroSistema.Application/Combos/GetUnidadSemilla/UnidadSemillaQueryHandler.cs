using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadSemilla
{
    public class UnidadSemillaQueryHandler : IRequestHandler<UnidadSemillaQuery, IEnumerable<UnidadSemillaDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public UnidadSemillaQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UnidadSemillaDTO>> Handle(UnidadSemillaQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetUnidadSemillaAsync();

            return _mapper.Map<IEnumerable<UnidadSemillaDTO>>(response);
        }
    }
}
