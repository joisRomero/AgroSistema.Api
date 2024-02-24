using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ListaPaginadaTipoTrabajador
{
    public class ListaPaginadaTipoTrabajadorCommandHandler : IRequestHandler<ListaPaginadaTipoTrabajadorCommand, PaginatedDTO<IEnumerable<TipoTrabajadorPaginadoDTO>>>
    {
        private readonly ITipoTrabajador _tipoTrabajador;
        private readonly IMapper _mapper;
        public ListaPaginadaTipoTrabajadorCommandHandler(ITipoTrabajador tipoTrabajador, IMapper mapper)
        {
            _tipoTrabajador = tipoTrabajador;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<TipoTrabajadorPaginadoDTO>>> Handle(ListaPaginadaTipoTrabajadorCommand request, CancellationToken cancellationToken)
        {
            RequestListaPaginadaTipoTrabajadorEntity entity = new()
            {
                NombreTipoTrabajador = request.NombreTipoTrabajador,
                IdUsuario = request.IdUsuario,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };

            var result = await _tipoTrabajador.ListarPaginadaTipoTrabajadorAsync(entity);
            var response = new PaginatedDTO<IEnumerable<TipoTrabajadorPaginadoDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<TipoTrabajadorPaginadoDTO>>(result.Data));

            return response;
        }
    }
}
