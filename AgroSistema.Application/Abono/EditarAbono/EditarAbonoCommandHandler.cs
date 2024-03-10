using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EditarAbonoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.EditarAbono
{
    public class EditarAbonoCommandHandler : IRequestHandler<EditarAbonoCommand>
    {
        private readonly IAbonoRepository _abonoRepository;

        public EditarAbonoCommandHandler(IAbonoRepository abonoRepository)
        {
            _abonoRepository = abonoRepository;
        }

        public async Task<Unit> Handle(EditarAbonoCommand request, CancellationToken cancellationToken)
        {
            EditarAbonoEntity editarAbonoEntity = new()
            {
                IdAbono = request.IdAbono,
                NombreAbono = request.NombreAbono,
                Descripcion = request.Descripcion,
                UsuarioModifica = request.UsuarioModifica
            };

            await _abonoRepository.EditarAbono(editarAbonoEntity);

            return Unit.Value;
        }
    }
}
