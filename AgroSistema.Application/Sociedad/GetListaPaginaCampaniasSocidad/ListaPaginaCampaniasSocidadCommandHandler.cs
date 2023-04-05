using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AutoMapper;
using MediatR;

namespace AgroSistema.Application.Sociedad.GetListaPaginaCampaniasSocidad
{
    public class ListaPaginaCampaniasSocidadCommandHandler : IRequestHandler<ListaPaginaCampaniasSocidadCommand, PaginatedDTO<IEnumerable<CampaniasSocidadPaginadaDTO>>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;

        public ListaPaginaCampaniasSocidadCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<CampaniasSocidadPaginadaDTO>>> Handle(ListaPaginaCampaniasSocidadCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaCampaniasSociedadEntity entity = new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                IdSociedad = request.IdSociedad
            };

            var result = await _sociedadRepository.GetListaPaginaCampaniasSocidadAsync(entity);
            var response = new PaginatedDTO<IEnumerable<CampaniasSocidadPaginadaDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<CampaniasSocidadPaginadaDTO>>(result.Data));
            
            return response;
        }
    }
}
