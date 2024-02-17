using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.GetListaPaginadaCampanias
{
    public class ListaPaginaCampaniasUsuarioCommandHandler : IRequestHandler<ListaPaginaCampaniasUsuarioCommand, PaginatedDTO<IEnumerable<CampaniasUsuarioPaginadaDTO>>>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        private readonly IMapper _mapper;

        public ListaPaginaCampaniasUsuarioCommandHandler(ICampaniaRepository campaniaRepository, IMapper mapper)
        {
            _campaniaRepository = campaniaRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedDTO<IEnumerable<CampaniasUsuarioPaginadaDTO>>> Handle(ListaPaginaCampaniasUsuarioCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaCampaniasUsuarioEntity entity = new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                IdUsuario = request.IdUsuario,
                Nombre = request.Nombre
            };

            var result = await _campaniaRepository.GetListaPaginaCampaniasUsuarioAsync(entity);
            var response = new PaginatedDTO<IEnumerable<CampaniasUsuarioPaginadaDTO>>(result.PageNumber,
                result.PageSize,
                result.TotalRows,
                _mapper.Map<IEnumerable<CampaniasUsuarioPaginadaDTO>>(result.Data));

            return response;
        }
    }
}
