using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListaPaginadaSociedadAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListarSociedad
{
    public class ListarSociedadQueryHandler : IRequestHandler<ListarSociedadQuery, PaginatedDTO<IEnumerable<ListarSociedadesDTO>>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;


        public ListarSociedadQueryHandler(ISociedadRepository sociedadRepository, IMapper mapper)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<ListarSociedadesDTO>>> Handle(ListarSociedadQuery request, CancellationToken cancellationToken)
        {
            RequestListaPaginadaSociedadesEntity entity = new RequestListaPaginadaSociedadesEntity()
            {
                NombreSociedad = request.NombreSociedad,
                IdUsuario = request.IdUsuario,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _sociedadRepository.ListarSociedades(entity);
            var response = new PaginatedDTO<IEnumerable<ListarSociedadesDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<ListarSociedadesDTO>>(result.Data));

            return response;
        }
    }
}
