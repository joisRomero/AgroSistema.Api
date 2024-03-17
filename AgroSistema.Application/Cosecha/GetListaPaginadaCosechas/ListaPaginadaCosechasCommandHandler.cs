using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.GetListaPaginadaCosechas
{
    public class ListaPaginadaCosechasCommandHandler : IRequestHandler<ListaPaginadaCosechasCommand, PaginatedDTO<IEnumerable<CosechasPaginadaDTO>>>
    {
        private readonly ICosechaRepository _cosechaRepository;
        private readonly IMapper _mapper;

        public ListaPaginadaCosechasCommandHandler(ICosechaRepository cosechaRepository, IMapper mapper)
        {
            _cosechaRepository = cosechaRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedDTO<IEnumerable<CosechasPaginadaDTO>>> Handle(ListaPaginadaCosechasCommand request, CancellationToken cancellationToken)
        {
            ListaPaginadaCosechasEntity entity = new()
            {
                IdCampania = request.IdCampania,
                FechaCosecha = request.FechaCosecha,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _cosechaRepository.GetListaPaginadaCosechasAsync(entity);
            var response = new PaginatedDTO<IEnumerable<CosechasPaginadaDTO>>(result.PageNumber, result.PageSize, result.TotalRows, _mapper.Map<IEnumerable<CosechasPaginadaDTO>>(result.Data));

            return response;
        }
    }
}
