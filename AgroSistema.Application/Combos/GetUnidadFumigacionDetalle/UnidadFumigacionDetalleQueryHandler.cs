using AgroSistema.Application.Combos.GetUnidadFumigacion;
using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadFumigacionDetalle
{
    public class UnidadFumigacionDetalleQueryHandler : IRequestHandler<UnidadFumigacionDetalleQuery, IEnumerable<UnidadFumigacionDetalleDTO>>
    {
        private readonly ICombosRepository _combosRepository;
        private readonly IMapper _mapper;
        public UnidadFumigacionDetalleQueryHandler(ICombosRepository combosRepository, IMapper mapper)
        {
            _combosRepository = combosRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UnidadFumigacionDetalleDTO>> Handle(UnidadFumigacionDetalleQuery request, CancellationToken cancellationToken)
        {
            var response = await _combosRepository.GetUnidadFumigacionDetalleAsync();

            return _mapper.Map<IEnumerable<UnidadFumigacionDetalleDTO>>(response);
        }
    }
}
