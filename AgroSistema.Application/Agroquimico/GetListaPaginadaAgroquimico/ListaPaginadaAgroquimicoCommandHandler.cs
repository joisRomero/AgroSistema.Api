using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.GetListaPaginadaAgroquimico
{
    public class ListaPaginadaAgroquimicoCommandHandler : IRequestHandler<ListaPaginadaAgroquimicoCommand, PaginatedDTO<IEnumerable<AgroquimicoPaginadoDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IAgroquimicoRepository _agroquimicoRepository;

        public ListaPaginadaAgroquimicoCommandHandler(IMapper mapper, IAgroquimicoRepository agroquimicoRepository)
        {
            _mapper = mapper;
            _agroquimicoRepository = agroquimicoRepository;
        }

        public async Task<PaginatedDTO<IEnumerable<AgroquimicoPaginadoDTO>>> Handle(ListaPaginadaAgroquimicoCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaAgroquimicoEntity entity = new()
            {
                IdUsuario = request.IdUsuario,
                IdTipoAgroquimico = request.IdTipoAgroquimico,
                Nombre = request.Nombre,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _agroquimicoRepository.GetListaPaginadaAgroquimicoAsync(entity);
            var response = new PaginatedDTO<IEnumerable<AgroquimicoPaginadoDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<AgroquimicoPaginadoDTO>>(result.Data));

            return response;
        }
    }
}
