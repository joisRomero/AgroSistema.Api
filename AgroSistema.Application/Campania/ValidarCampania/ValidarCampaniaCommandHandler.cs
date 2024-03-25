using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Exceptions;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Settings;
using AgroSistema.Domain.Entities.ValidarCampaniaAsync;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ValidarCampania
{
    public class ValidarCampaniaCommandHandler : IRequestHandler<ValidarCampaniaCommand, ValidarCampaniaDTO>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        private readonly ILogger<ValidarCampaniaCommandHandler> _logger;
        private readonly IEnumerable<MensajeUsuarioDTO> _mensajesUsuario;

        public ValidarCampaniaCommandHandler(ICampaniaRepository campaniaRepository, ILogger<ValidarCampaniaCommandHandler> logger, IMemoryCache memoryCache)
        {
            _campaniaRepository = campaniaRepository; 
            _logger = logger;
            _mensajesUsuario = memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey);
        }

        public async Task<ValidarCampaniaDTO> Handle(ValidarCampaniaCommand request, CancellationToken cancellationToken)
        {
            ValidarCampaniaEntity validarCampaniaEntity = new()
            {
                IdUsuario = request.IdUsuario,
                IdCampania = request.IdCampania,
            };

            var respuesta = await _campaniaRepository.ValidarCampania(validarCampaniaEntity);

            if (respuesta.Respuesta == 1)
            {
                throw new BadRequestException(_mensajesUsuario.FirstOrDefault(m => m.Codigo == "000009"));
            }

            return new ValidarCampaniaDTO() { NombreCampania = respuesta.NombreCampania, EstadoProceso = respuesta.EstadoProceso};
        }
    }
}
