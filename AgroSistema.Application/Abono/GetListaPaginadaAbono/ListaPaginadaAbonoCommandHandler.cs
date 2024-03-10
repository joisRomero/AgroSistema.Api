using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ListaPaginadaAbonoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.GetListaPaginadaAbono
{
    public class ListaPaginadaAbonoCommandHandler : IRequestHandler<ListaPaginadaAbonoCommand, PaginatedDTO<IEnumerable<AbonoPaginadoDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IAbonoRepository _abonoRepository;

        public ListaPaginadaAbonoCommandHandler(IMapper mapper, IAbonoRepository abonoRepository)
        {
            _mapper = mapper;
            _abonoRepository = abonoRepository;
        }

        public async Task<PaginatedDTO<IEnumerable<AbonoPaginadoDTO>>> Handle(ListaPaginadaAbonoCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaAbonoEntity entity = new()
            {
                IdUsuario = request.IdUsuario,
                Nombre = request.Nombre,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _abonoRepository.GetListaPaginadaAbonoAsync(entity);
            var response = new PaginatedDTO<IEnumerable<AbonoPaginadoDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<AbonoPaginadoDTO>>(result.Data));

            return response;
        }
    }
}
