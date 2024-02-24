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
    public class ListaPaginadaTipoActividadCommandHandler :IRequestHandler<ListaPaginadaTipoActividadCommand, IEnumerable<TipoActividadPaginadaDTO>>
    {
        private readonly ITipoActividad _tipoActividad;
        private readonly IMapper _mapper;
        public ListaPaginadaTipoActividadCommandHandler(ITipoActividad tipoActividad, IMapper mapper)
        {
            _tipoActividad = tipoActividad;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoActividadPaginadaDTO>> Handle(ListaPaginadaTipoActividadCommand request, CancellationToken cancellationToken)
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

            return _mapper.Map<IEnumerable<TipoActividadPaginadaDTO>>(response);
        }
    }
}
