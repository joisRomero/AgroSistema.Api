using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ObtenerCampania
{
    public class ObtenerCampaniaCommandHandler : IRequestHandler<ObtenerCampaniaCommand, ObtenerCampaniaCommandDTO>
    {
        public readonly ICampaniaRepository _campaniaRepository;
        public readonly IMapper _mapper;

        public ObtenerCampaniaCommandHandler(ICampaniaRepository campaniaRepository, IMapper mapper)
        {
            _campaniaRepository = campaniaRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerCampaniaCommandDTO> Handle(ObtenerCampaniaCommand request, CancellationToken cancellationToken)
        {
            var response = await _campaniaRepository.ObtenerCampaniaAsync(request.IdCampania);
            return _mapper.Map<ObtenerCampaniaCommandDTO>(response);
        }
    }
}
