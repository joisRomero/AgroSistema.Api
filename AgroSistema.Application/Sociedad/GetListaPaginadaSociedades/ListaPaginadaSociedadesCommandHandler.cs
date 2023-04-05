using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.GetListaPaginadaSociedades
{
    public class ListaPaginadaSociedadesCommandHandler : IRequestHandler<ListaPaginadaSociedadesCommand, PaginatedDTO<IEnumerable<SociedadPaginadaDTO>>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;

        public ListaPaginadaSociedadesCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<SociedadPaginadaDTO>>> Handle(ListaPaginadaSociedadesCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaSociedadEntity entity = new()
            {
                Nombre = request.Nombre,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                IdUsuario = request.IdUsuario
            };

            var result = await _sociedadRepository.GetListaPaginadaSociedadesAsync(entity);
            var response = new PaginatedDTO<IEnumerable<SociedadPaginadaDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<SociedadPaginadaDTO>>(result.Data));

            return response;
        }
    }
}
