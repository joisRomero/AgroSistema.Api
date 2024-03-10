using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarAgroquimicoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.EliminarAgroquimico
{
    public class EliminarAgroquimicoCommandHandler : IRequestHandler<EliminarAgroquimicoCommand>
    {
        private readonly IAgroquimicoRepository _agroquimicoRepository;

        public EliminarAgroquimicoCommandHandler(IAgroquimicoRepository agroquimicoRepository)
        {
            _agroquimicoRepository = agroquimicoRepository;
        }

        public async Task<Unit> Handle(EliminarAgroquimicoCommand request, CancellationToken cancellationToken)
        {
            EliminarAgroquimicoEntity eliminarAgroquimicoEntity = new()
            {
                IdAgroquimico = request.IdAgroquimico,
                UsuarioElimina = request.UsuarioElimina
            };

            await _agroquimicoRepository.EliminarAgroquimico(eliminarAgroquimicoEntity);

            return Unit.Value;
        }
    }
}
