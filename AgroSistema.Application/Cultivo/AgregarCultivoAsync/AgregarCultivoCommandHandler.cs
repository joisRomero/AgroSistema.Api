using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.AgregarCultivoAsync
{
    public class AgregarCultivoCommandHandler : IRequestHandler<AgregarCultivoCommand>
    {
        private readonly ICultivoRepository _cultivoRepository;
        private readonly ILogger<AgregarCultivoCommandHandler> _logger;

        public AgregarCultivoCommandHandler(ICultivoRepository cultivoRepository, 
            ILogger<AgregarCultivoCommandHandler> logger)
        {
            _cultivoRepository = cultivoRepository;
            _logger = logger;
        }   

        public async Task<Unit> Handle(AgregarCultivoCommand request, CancellationToken cancellationToken)
        {
            AgregarCultivoEntity agregarCultivoEntity = new()
            {
                NombreCultivo = request.NombreCultivo,
                IdUsuario = request.IdUsuario,
                UsuarioInserta = request.UsuarioInserta
            };

            await _cultivoRepository.AgregarCultivo(agregarCultivoEntity);
            return Unit.Value;
        }
    }
}
