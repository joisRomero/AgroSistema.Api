using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Settings;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad
{
    public class ObtenerIntegrantesSociedadCommandHandler : IRequestHandler<ObtenerIntegrantesSociedadCommand, PaginatedDTO<IEnumerable<IntegrantesSociedadDTO>>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;

        public ObtenerIntegrantesSociedadCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<IntegrantesSociedadDTO>>> Handle(ObtenerIntegrantesSociedadCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaIntegrantesSociedadEntity entity = new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                IdSociedad = request.IdSociedad,
                Nombre = request.Nombre,
            };

            var resultado = await _sociedadRepository.ObtenerIntegrantesSociedadAsync(entity);
            var response = new PaginatedDTO<IEnumerable<IntegrantesSociedadDTO>>(resultado.PageNumber, 
                resultado.PageSize, 
                resultado.TotalRows, 
                _mapper.Map<IEnumerable<IntegrantesSociedadDTO>>(resultado.Data));

            return response;   
        }
    }
}
