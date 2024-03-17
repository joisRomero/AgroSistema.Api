using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.ObtenerCosecha
{
    public class ObtenerCosechaCommandHandler : IRequestHandler<ObtenerCosechaCommand, ObtenerCosechaDTO>
    {
        private readonly ICosechaRepository _cosechaRepository;
        private readonly IMapper _mapper;

        public ObtenerCosechaCommandHandler(ICosechaRepository cosechaRepository, IMapper mapper)
        {
            _cosechaRepository = cosechaRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerCosechaDTO> Handle(ObtenerCosechaCommand request, CancellationToken cancellationToken)
        {
            var result = await _cosechaRepository.GetCosechaPorIdAsync(request.IdCosecha);

            var resultDetalle = await _cosechaRepository.GetCosechaDetallePorIdAsync(request.IdCosecha);

            var listaCosechaDetalle = _mapper.Map<IEnumerable<DetalleCosechaDetalleDTO>>(resultDetalle);

            ObtenerCosechaDTO response = new()
            {
                IdCosecha = result.IdCosecha,
                FechaCosecha = result.FechaCosecha,
                Descripcion = result.Descripcion,
                IdCampania = result.IdCampania,
                ListaDetalleCosecha = listaCosechaDetalle
            };

            return response;
        }
    }
}
