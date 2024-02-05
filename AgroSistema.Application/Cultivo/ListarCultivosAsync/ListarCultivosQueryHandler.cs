using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Sociedad.GetListaPaginadaCampaniasSocidad;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.ListarCultivosAsync
{
    public class ListarCultivosQueryHandler : IRequestHandler<ListarCultivosQuery , PaginatedDTO<IEnumerable<ListarCultivosDTO>>>
    {
        private readonly ICultivoRepository _cultivoRepository;
        private readonly IMapper _mapper;

        public ListarCultivosQueryHandler(ICultivoRepository cultivoRepository , IMapper mapper)
        {
            _cultivoRepository = cultivoRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<ListarCultivosDTO>>> Handle(ListarCultivosQuery request, CancellationToken cancellationToken)
        {
            RequestListaPaginadaCultivoEntity entity = new RequestListaPaginadaCultivoEntity()
            {
                NombreCultivo = request.NombreCultivo,
                IdUsuario = request.IdUsuario,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _cultivoRepository.ListarCultivosAsync(entity);
            var response = new PaginatedDTO<IEnumerable<ListarCultivosDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<ListarCultivosDTO>>(result.Data));

            return response;
        }
    }
}
