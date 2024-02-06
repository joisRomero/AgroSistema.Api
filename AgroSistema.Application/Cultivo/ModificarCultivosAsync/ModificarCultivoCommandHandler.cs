using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ModificarCultivoAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.ModificarCultivosAsync
{
    public class ModificarCultivoCommandHandler : IRequestHandler<ModificarCultivoCommand>
    {
        private readonly ICultivoRepository _cultivoRepository;
        private readonly ILogger<ModificarCultivoCommandHandler> _logger;

        public ModificarCultivoCommandHandler(ICultivoRepository cultivoRepository,ILogger<ModificarCultivoCommandHandler> logger)
        {
            _cultivoRepository = cultivoRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(ModificarCultivoCommand request, CancellationToken cancellationToken)
        {
            ModificarCultivoEntity modificarCultivoEntity = new()
            {
                IdCultivo = request.IdCultivo,
                NombreCultivo = request.NombreCultivo,
                IdUsuario = request.IdUsuario,
                UsuarioModifica = request.UsuarioModifica
            };

            await _cultivoRepository.ModificarCultivo(modificarCultivoEntity);
            return Unit.Value;
        }
    }
}
