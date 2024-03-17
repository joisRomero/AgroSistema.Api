using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarCosechaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.EliminarCosecha
{
    public class EliminarCosechaCommandHandler : IRequestHandler<EliminarCosechaCommand>
    {
        private readonly ICosechaRepository _cosechaRepository;

        public EliminarCosechaCommandHandler(ICosechaRepository cosechaRepository)
        {
            _cosechaRepository = cosechaRepository;
        }

        public async Task<Unit> Handle(EliminarCosechaCommand request, CancellationToken cancellationToken)
        {
            EliminarCosechaEntity entity = new()
            {
                IdCosecha = request.IdCosecha,
                UsuarioElimina = request.UsuarioElimina
            };

            await _cosechaRepository.EliminarCosecha(entity);

            return Unit.Value;
        }
    }
}
