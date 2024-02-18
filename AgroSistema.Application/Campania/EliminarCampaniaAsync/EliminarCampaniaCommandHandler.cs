using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarCampaniaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.EliminarCampaniaAsync
{
    public class EliminarCampaniaCommandHandler : IRequestHandler<EliminarCampaniaCommand>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        public EliminarCampaniaCommandHandler(ICampaniaRepository campaniaRepository)
        {
            _campaniaRepository = campaniaRepository;
        }

        public async Task<Unit> Handle(EliminarCampaniaCommand request, CancellationToken cancellationToken)
        {
            EliminarCampaniaEntity entity = new()
            {
                IdCampania = request.IdCampania,
                UsuarioElimina = request.UsuarioElimina
            };

            await _campaniaRepository.EliminarCampaniaAsync(entity);
            return Unit.Value;
        }
    }
}
