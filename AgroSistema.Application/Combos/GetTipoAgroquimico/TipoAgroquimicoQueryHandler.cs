using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;

namespace AgroSistema.Application.Combos.GetTipoAgroquimico
{
    public class TipoAgroquimicoQueryHandler : IRequestHandler<TipoAgroquimicoQuery, IEnumerable<TipoAgroquimicoDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public TipoAgroquimicoQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TipoAgroquimicoDTO>> Handle(TipoAgroquimicoQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetTipoAgroquimicoAsync();

            return _mapper.Map<IEnumerable<TipoAgroquimicoDTO>>(response);
        }
    }
}
