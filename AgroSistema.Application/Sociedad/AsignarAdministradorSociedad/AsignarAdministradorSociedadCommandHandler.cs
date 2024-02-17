using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.AsignarAdministradorAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.AsignarAdministradorSociedad
{
    public class AsignarAdministradorSociedadCommandHandler : IRequestHandler<AsignarAdministradorSociedadCommand>
    {
        private readonly ISociedadRepository _sociedadRepository;

        public AsignarAdministradorSociedadCommandHandler(ISociedadRepository sociedadRepository)
        {
            _sociedadRepository = sociedadRepository;
        }
        public async Task<Unit> Handle(AsignarAdministradorSociedadCommand request, CancellationToken cancellationToken)
        {
            AsignarAdministradorSociedadEntity asignarAdministradorSociedadEntity = new()
            {
                IdUsuario = request.IdUsuario,
                IdSociedad = request.IdSociedad,
                UsuarioModifica = request.UsuarioModifica,
                Accion = request.Accion
            };


            await _sociedadRepository.AsignarAdministradorSociedadAsync(asignarAdministradorSociedadEntity);
            return Unit.Value;
        }
    }
}
