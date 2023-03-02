using AutoMapper;
using MediatR;
using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.MensajeUsuario.Queries
{
    public class GetMensajesUsuarioQueryHandler : IRequestHandler<GetMensajesUsuarioQuery, IEnumerable<MensajeUsuarioDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMensajeUsuarioRepository _mensajeUsuarioRepository;

        public GetMensajesUsuarioQueryHandler(IMapper mapper, IMensajeUsuarioRepository mensajeUsuarioRepository)
        {
            _mapper = mapper;
            _mensajeUsuarioRepository = mensajeUsuarioRepository;
        }

        public async Task<IEnumerable<MensajeUsuarioDTO>> Handle(GetMensajesUsuarioQuery request, CancellationToken cancellationToken)
        {
            var listaMensajesEntity = await _mensajeUsuarioRepository.GetListaAsync(request.AplicacionId);
            return _mapper.Map<IEnumerable<MensajeUsuarioDTO>>(listaMensajesEntity);
        }
    }
}
