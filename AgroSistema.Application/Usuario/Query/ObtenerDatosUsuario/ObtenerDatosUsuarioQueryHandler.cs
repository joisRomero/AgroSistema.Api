using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.ObtenerDatosUsuario
{
    public class ObtenerDatosUsuarioQueryHandler : IRequestHandler<ObtenerDatosUsuarioQuery, ObtenerDatosUsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public ObtenerDatosUsuarioQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerDatosUsuarioDTO> Handle(ObtenerDatosUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioRepository.ObtenerDatosUsuario(request.IdUsuario) 
                ?? throw new BadRequestException(new Common.Dtos.MensajeUsuarioDTO() { Descripcion = "No se encontraron datos del usuario" });

            return _mapper.Map<ObtenerDatosUsuarioDTO>(result);
        }
    }
}
