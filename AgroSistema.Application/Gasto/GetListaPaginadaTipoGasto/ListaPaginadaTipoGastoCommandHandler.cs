using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Sociedad.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto
{
    public class ListaPaginadaTipoGastoCommandHandler : IRequestHandler<ListaPaginadaTipoGastoCommand, PaginatedDTO<IEnumerable<TipoGastoPaginadoDTO>>>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public ListaPaginadaTipoGastoCommandHandler(IGastoRepository gastoRepository, IMapper mapper)
        {
            _gastoRepository = gastoRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<TipoGastoPaginadoDTO>>> Handle(ListaPaginadaTipoGastoCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaTipoGastoEntity entity = new()
            {
                IdUsuario = request.IdUsuario,
                Nombre = request.Nombre,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _gastoRepository.GetListaPaginadaTipoGastoAsync(entity);
            var response = new PaginatedDTO<IEnumerable<TipoGastoPaginadoDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<TipoGastoPaginadoDTO>>(result.Data));

            return response;

        }
    }
}
