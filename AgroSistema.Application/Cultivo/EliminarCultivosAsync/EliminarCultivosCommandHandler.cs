using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarCultivoAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.EliminarCultivosAsync
{
    public class EliminarCultivosCommandHandler :IRequestHandler<EliminarCultivosCommand>
    {
        private readonly ICultivoRepository _cultivoRepository;
        private readonly ILogger<EliminarCultivosCommandHandler> _logger;

        public EliminarCultivosCommandHandler(ICultivoRepository cultivoRepository, ILogger<EliminarCultivosCommandHandler> logger)
        {
            _cultivoRepository = cultivoRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(EliminarCultivosCommand request, CancellationToken cancellationToken)
        {
            EliminarCultivoEntity eliminarCultivoEntity = new()
            {
                IdCultivo = request.IdCultivo,
                UsuarioElimina = request.UsuarioElimina
            };

            await _cultivoRepository.EliminarCultivo(eliminarCultivoEntity);

            return Unit.Value;
        }
    }
}
