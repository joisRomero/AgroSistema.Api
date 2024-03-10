using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EditarAgroquimicoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.EditarAgroquimico
{
    public class EditarAgroquimicoCommandHandler : IRequestHandler<EditarAgroquimicoCommand>
    {
        private readonly IAgroquimicoRepository _agroquimicoRepository;

        public EditarAgroquimicoCommandHandler(IAgroquimicoRepository agroquimicoRepository)
        {
            _agroquimicoRepository = agroquimicoRepository;
        }

        public async Task<Unit> Handle(EditarAgroquimicoCommand request, CancellationToken cancellationToken)
        {
            EditarAgroquimicoEntity editarAgroquimicoEntity = new()
            {
                IdAgroquimico = request.IdAgroquimico,
                IdTipoAgroquimico = request.IdTipoAgroquimico,
                NombreAgroquimico = request.NombreAgroquimico,
                Descripcion = request.Descripcion,
                UsuarioModifica = request.UsuarioModifica
            };

            await _agroquimicoRepository.EditarAgroquimico(editarAgroquimicoEntity);

            return Unit.Value;
        }
    }
}
