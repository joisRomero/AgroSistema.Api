using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.RetirarseUsuarioSociedadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.RetirarseUsuarioSociedad
{
    public class RetirarseUsuarioSociedadCommandHandler : IRequestHandler<RetirarseUsuarioSociedadCommand>
    {
        private readonly ISociedadRepository _sociedadRepository;

        public RetirarseUsuarioSociedadCommandHandler(ISociedadRepository sociedadRepository)
        {
            _sociedadRepository = sociedadRepository;
        }
        public async Task<Unit> Handle(RetirarseUsuarioSociedadCommand request, CancellationToken cancellationToken)
        {
            RetirarseUsuarioSociedadEntity retirarseUsuarioSociedadEntity = new()
            {
                IdUsuario = request.IdUsuario,
                IdSociedad = request.IdSociedad,
                UsuarioModifica = request.UsuarioModifica
            };

            await _sociedadRepository.RetirarseUsuarioSociedadAsync(retirarseUsuarioSociedadEntity);
            return Unit.Value;
        }
    }
}
