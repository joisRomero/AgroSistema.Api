using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.GetAgroquimico
{
    public class ObtenerAgroquimicoCommandHandler : IRequestHandler<ObtenerAgroquimicoCommand, ObtenerAgroquimicoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAgroquimicoRepository _agroquimicoRepository;

        public ObtenerAgroquimicoCommandHandler(IMapper mapper, IAgroquimicoRepository agroquimicoRepository)
        {
            _mapper = mapper;
            _agroquimicoRepository = agroquimicoRepository;
        }

        public async Task<ObtenerAgroquimicoDTO> Handle(ObtenerAgroquimicoCommand request, CancellationToken cancellationToken)
        {
            var result = await _agroquimicoRepository.GetAgroquimicoPorIdAsync(request.IdAgroquimico);

            return _mapper.Map<ObtenerAgroquimicoDTO>(result);
        }
    }
}
