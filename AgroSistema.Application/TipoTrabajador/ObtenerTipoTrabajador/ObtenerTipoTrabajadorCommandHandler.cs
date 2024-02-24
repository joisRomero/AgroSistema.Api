using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ObtenerTipoTrabajador
{
    public class ObtenerTipoTrabajadorCommandHandler : IRequestHandler<ObtenerTipoTrabajadorCommand, TipoTrabajadorDTO>
    {
        private readonly ITipoTrabajador _tipoTrabajador;
        private readonly IMapper _mapper;

        public ObtenerTipoTrabajadorCommandHandler(ITipoTrabajador tipoTrabajador , IMapper mapper)
        {
            _tipoTrabajador = tipoTrabajador;
            _mapper = mapper;
        }
        public async Task<TipoTrabajadorDTO> Handle(ObtenerTipoTrabajadorCommand request, CancellationToken cancellationToken)
        {
            var response = await _tipoTrabajador.ObtenerTipoTrabajadorAsync(request.IdTipoTrabajador);

            return _mapper.Map<TipoTrabajadorDTO>(response);
        }
    }
}
