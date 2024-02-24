using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle
{
    public class ListaPaginadaGastoDetalleCommandHandler : IRequestHandler<ListaPaginadaGastoDetalleCommand, PaginatedDTO<IEnumerable<GastoDetallePaginadoDTO>>>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public ListaPaginadaGastoDetalleCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<GastoDetallePaginadoDTO>>> Handle(ListaPaginadaGastoDetalleCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaGastoDetalleEntity entity = new()
            {
                IdCampania = request.IdCampania,
                IdTipoGasto = request.IdTipoGasto,
                FechaGasto = request.FechaGasto,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _gastoRepository.GetListaPaginadaGastoDetalleAsync(entity);
            var response = new PaginatedDTO<IEnumerable<GastoDetallePaginadoDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<GastoDetallePaginadoDTO>>(result.Data));

            return response;

        }
    }
}
