using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListaBusquedaIntegrante
{
    public class ListaBusquedaIntegranteCommandHandler : IRequestHandler<ListaBusquedaIntegranteCommand, IEnumerable<BusquedaIntegranteDTO>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;
        public ListaBusquedaIntegranteCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BusquedaIntegranteDTO>> Handle(ListaBusquedaIntegranteCommand request, CancellationToken cancellationToken)
        {
            BusquedaIntegranteEntity entity = new()
            {
                Nombre = request.Nombre,
                IdUsuario = request.IdUsuario
            };

            var result = await _sociedadRepository.ListaBusquedaIntegranteAsync(entity);

            return _mapper.Map<IEnumerable<BusquedaIntegranteDTO>>(result);
        }
    }
}
