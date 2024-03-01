using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListaPaginadoActividadesAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarActividadesPaginadoAsync
{
    public class ListarActividadesPaginadoCommandHandler : IRequestHandler<ListarActividadesPaginadoCommand, PaginatedDTO<IEnumerable<ActividadesPaginadoDTO>>>
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IMapper _mapper;
        public ListarActividadesPaginadoCommandHandler(IActividadRepository actividadRepository, IMapper mapper)
        {
            _actividadRepository = actividadRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<ActividadesPaginadoDTO>>> Handle(ListarActividadesPaginadoCommand request, CancellationToken cancellationToken)
        {
            RequestListaPaginadoActividadesEntity requestListaPaginadoActividadesEntity = new()
            {
                IdCampania = request.IdCampania,
                FechaActividad = request.FechaActividad,
                IdTipoActividad = request.IdTipoActividad,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };

            var response = await _actividadRepository.ListaPaginadoActividadesAsync(requestListaPaginadoActividadesEntity);

            return _mapper.Map<PaginatedDTO<IEnumerable<ActividadesPaginadoDTO>>>(response);
        }
    }
}
