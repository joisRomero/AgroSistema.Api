using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarDetalleActividadAsync
{
    public class ListarDetalleActividadCommandHandler : IRequestHandler<ListarDetalleActividadCommand, DetalleActividadDTO>
    {
        private readonly IActividadRepository _actividadRepository;
        private readonly IMapper _mapper;
        public ListarDetalleActividadCommandHandler(IActividadRepository actividadRepository , IMapper mapper)
        {
            _actividadRepository = actividadRepository;
            _mapper = mapper;
        }

        public async Task<DetalleActividadDTO> Handle(ListarDetalleActividadCommand request, CancellationToken cancellationToken)
        {
            var datosActividad = await _actividadRepository.ObtenerDetalleActividadAsync(request.IdActividad);
            var listaTrabajadores = await _actividadRepository.ObtenerTrabajadoresActividadAsync(request.IdActividad);
            var listaGastos = await _actividadRepository.ObtenerGatosActividadAsync(request.IdActividad);

            var detalleTrabajadores = _mapper.Map<IEnumerable<DetalleTrabajadoresDTO>>(listaTrabajadores);
            var detalleGastos = _mapper.Map<IEnumerable<DetalleGastosDTO>> (listaGastos);
            var actividadDetalle = new DetalleActividadDTO()
            {
                IdActividad = datosActividad.IdActividad,
                FechaActividad = datosActividad.FechaActividad,
                DescripcionActividad = datosActividad.DescripcionActividad,
                IdTipoActividad = datosActividad.IdTipoActividad,
                DescripcionTipoActividad = datosActividad.DescripcionTipoActividad,
                ListaDetalleTrabajadores = detalleTrabajadores,
                LsitaDetalleGastos = detalleGastos
            };

            return actividadDetalle;
        }
    }
}
