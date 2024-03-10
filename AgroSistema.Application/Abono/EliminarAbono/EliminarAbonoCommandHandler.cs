using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarAbonoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.EliminarAbono
{
    public class EliminarAbonoCommandHandler : IRequestHandler<EliminarAbonoCommand>
    {
        private readonly IAbonoRepository _abonoRepository;

        public EliminarAbonoCommandHandler(IAbonoRepository abonoRepository)
        {
            _abonoRepository = abonoRepository;
        }

        public async Task<Unit> Handle(EliminarAbonoCommand request, CancellationToken cancellationToken)
        {
            EliminarAbonoEntity eliminarAbonoEntity = new()
            {
                IdAbono = request.IdAbono,
                UsuarioElimina = request.UsuarioElimina
            };

            await _abonoRepository.EliminarAbono(eliminarAbonoEntity);

            return Unit.Value;
        }
    }
}
