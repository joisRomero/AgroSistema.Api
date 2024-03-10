using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.AgregarAgroquimicoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.AgregarAgroquimico
{
    public class AgregarAgroquimicoCommandHandler : IRequestHandler<AgregarAgroquimicoCommand>
    {
        private readonly IAgroquimicoRepository _agroquimicoRepository;

        public AgregarAgroquimicoCommandHandler(IAgroquimicoRepository agroquimicoRepository)
        {
            _agroquimicoRepository = agroquimicoRepository;
        }
        public async Task<Unit> Handle(AgregarAgroquimicoCommand request, CancellationToken cancellationToken)
        {
            AgregarAgroquimicoEntity agregarAgroquimicoEntity = new()
            {
                NombreAgroquimico = request.NombreAgroquimico,
                IdTipoAgroquimico = request.IdTipoAgroquimico,
                Descripcion = request.Descripcion,
                IdUsuario = request.IdUsuario,
                UsuarioInserta = request.UsuarioInserta
            };

            await _agroquimicoRepository.AgregarAgroquimico(agregarAgroquimicoEntity);

            return Unit.Value;
        }
    }
}
