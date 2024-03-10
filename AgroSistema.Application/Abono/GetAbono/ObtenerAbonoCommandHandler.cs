using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.GetAbono
{
    public class ObtenerAbonoCommandHandler : IRequestHandler<ObtenerAbonoCommand, ObtenerAbonoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAbonoRepository _abonoRepository;

        public ObtenerAbonoCommandHandler(IMapper mapper, IAbonoRepository abonoRepository)
        {
            _mapper = mapper;
            _abonoRepository = abonoRepository;
        }

        public async Task<ObtenerAbonoDTO> Handle(ObtenerAbonoCommand request, CancellationToken cancellationToken)
        {
            var result = await _abonoRepository.GetAbonoPorIdAsync(request.IdAbono);

            return _mapper.Map<ObtenerAbonoDTO>(result);
        }
    }
}
