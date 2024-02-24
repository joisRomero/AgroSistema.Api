using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ObtenerTipoActividad
{
    public class ObtenerTipoActividadCommandHandler : IRequestHandler<ObtenerTipoActividadCommand, ObtenerTipoActividadDTO>
    {
        private readonly ITipoActividad _tipoActividad;
        private readonly IMapper _mapper;
        public ObtenerTipoActividadCommandHandler(ITipoActividad tipoActividad,IMapper mapper)
        {
            _tipoActividad = tipoActividad;
            _mapper = mapper;
        }
        public async Task<ObtenerTipoActividadDTO> Handle(ObtenerTipoActividadCommand request, CancellationToken cancellationToken)
        {
            var response = await _tipoActividad.ObtenerTipoActividadAsync(request.IdTipoActividad);
            return _mapper.Map<ObtenerTipoActividadDTO>(response);
        }
    }
}
