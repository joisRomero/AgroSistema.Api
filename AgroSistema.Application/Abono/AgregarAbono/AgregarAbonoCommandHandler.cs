using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarAbonoAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.AgregarAbono
{
    public class AgregarAbonoCommandHandler : IRequestHandler<AgregarAbonoCommand>
    {
        private readonly IAbonoRepository _abonoRepository;

        public AgregarAbonoCommandHandler(IAbonoRepository abonoRepository)
        {
            _abonoRepository = abonoRepository;
        }

        public async Task<Unit> Handle(AgregarAbonoCommand request, CancellationToken cancellationToken)
        {
            AgregarAbonoEntity agregarAbonoEntity = new()
            {
                NombreAbono = request.NombreAbono,
                IdUsuario = request.IdUsuario,
                Descripcion = request.Descripcion,
                UsuarioInserta = request.UsuarioInserta
            };

            await _abonoRepository.AgregarAbono(agregarAbonoEntity);
            return Unit.Value;
        }
    }
}
