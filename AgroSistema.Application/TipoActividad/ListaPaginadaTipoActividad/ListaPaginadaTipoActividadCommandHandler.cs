using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ListaPaginadaTipoActividad
{
    public class ListaPaginadaTipoActividadCommandHandler :IRequestHandler<ListaPaginadaTipoActividadCommand, PaginatedDTO<IEnumerable<TipoActividadPaginadaDTO>>>
    {
        private readonly ITipoActividad _tipoActividad;
        private readonly IMapper _mapper;
        public ListaPaginadaTipoActividadCommandHandler(ITipoActividad tipoActividad, IMapper mapper)
        {
            _tipoActividad = tipoActividad;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<TipoActividadPaginadaDTO>>> Handle(ListaPaginadaTipoActividadCommand request, CancellationToken cancellationToken)
        {
            RequestListaPaginadaTipoActividadEntity requestListaPaginadaTipoActividadEntity = new()
            {
                NombreTipoActividad = request.NombreTipoActividad,
                RealizadaPorTipoActividad = request.RealizadaPorTipoActividad,
                IdUsuario = request.IdUsuario,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
            };

            var response = await _tipoActividad.ListaPaginadaTipoActividadAsync(requestListaPaginadaTipoActividadEntity);
            return new PaginatedDTO<IEnumerable<TipoActividadPaginadaDTO>>(response.PageNumber,
                response.PageSize,
                response.TotalRows,
                _mapper.Map<IEnumerable<TipoActividadPaginadaDTO>>(response.Data));

        }
    }
}
