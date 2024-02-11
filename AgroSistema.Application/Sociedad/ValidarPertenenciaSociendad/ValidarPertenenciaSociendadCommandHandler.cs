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

namespace AgroSistema.Application.Sociedad.ValidarPertenenciaSociendad
{
    public class ValidarPertenenciaSociendadCommandHandler : IRequestHandler<ValidarPertenenciaSociendadCommand, ValidarPertenenciaSociendadDTO>
    {
        private readonly ISociedadRepository _sociedadRepository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<MensajeUsuarioDTO> _mensajesUsuario;

        public ValidarPertenenciaSociendadCommandHandler(ISociedadRepository sociedadRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _sociedadRepository = sociedadRepository;
            _mapper = mapper;
            _mensajesUsuario = memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey);
        }

        public async Task<ValidarPertenenciaSociendadDTO> Handle(ValidarPertenenciaSociendadCommand request, CancellationToken cancellationToken)
        {
            var result = await _sociedadRepository.ValidarPertenenciaSociedad(request.IdUsuario, request.IdSociedad);

            if (result.Respuesta == 0)
            {
                throw new BadRequestException(_mensajesUsuario.FirstOrDefault(m => m.Codigo == "000008"));
            }
            else
            {
                return new ValidarPertenenciaSociendadDTO() { Respuesta = true,  EsAdministrador = result.EsAdministrador, NombreSociedad = result.NombreSociedad};
            }
        }
    }
}
