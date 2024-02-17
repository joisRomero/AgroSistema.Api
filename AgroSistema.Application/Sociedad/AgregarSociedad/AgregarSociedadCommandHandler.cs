using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cultivo.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.AgregarSociedad
{
    public class AgregarSociedadCommandHandler : IRequestHandler<AgregarSociedadCommand>
    {
        private readonly ISociedadRepository _sociedadRepository;

        public AgregarSociedadCommandHandler(ISociedadRepository sociedadRepository)
        {
            _sociedadRepository = sociedadRepository;
        }
        public async Task<Unit> Handle(AgregarSociedadCommand request, CancellationToken cancellationToken)
        {
            AgregarSociedadEntity agregarSociedadEntity = new()
            {
                NombreSociedad = request.NombreSociedad,
                IdUsuario = request.IdUsuario,
                UsuarioInserta = request.UsuarioInserta
            };

            await _sociedadRepository.AgregarSociedad(agregarSociedadEntity);
            return Unit.Value;
        }
    }
}
