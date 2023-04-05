using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Settings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad
{
    public class ObtenerIntegrantesSociedadCommandHandler : IRequestHandler<ObtenerIntegrantesSociedadCommand, IEnumerable<IntegrantesSociedadDTO>>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<MensajeUsuarioDTO> _mensajesUsuario;

        public ObtenerIntegrantesSociedadCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
            _mensajesUsuario = memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey);
        }

        public async Task<IEnumerable<IntegrantesSociedadDTO>> Handle(ObtenerIntegrantesSociedadCommand request, CancellationToken cancellationToken)
        {
            var respuesta = await _sociedadRepository.ValidarPertenenciaSociedad(request.IdUsuario, request.IdSociedad);

            if (respuesta == 1)
            {
               throw new BadRequestException(_mensajesUsuario.FirstOrDefault(m => m.Codigo == "000008"));
            } 
            else
            {
                var resultado = await _sociedadRepository.ObtenerIntegrantesSociedadAsync(request.IdSociedad);
                return _mapper.Map<IEnumerable<IntegrantesSociedadDTO>>(resultado);
            }

            throw new NotImplementedException();
        }
    }
}
