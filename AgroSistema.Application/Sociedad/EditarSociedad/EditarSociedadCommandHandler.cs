using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Cultivo.ModificarCultivosAsync;
using AgroSistema.Domain.Entities.EditarSociedadAsync;
using AgroSistema.Domain.Entities.ModificarCultivoAsync;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.EditarSociedad
{
    public class EditarSociedadCommandHandler : IRequestHandler<EditarSociedadCommand>
    {
        private readonly ISociedadRepository _sociedadRepository;

        public EditarSociedadCommandHandler(ISociedadRepository sociedadRepository)
        {
            _sociedadRepository = sociedadRepository;
        }

        public async Task<Unit> Handle(EditarSociedadCommand request, CancellationToken cancellationToken)
        {
            EditarSociedadEntity editarSociedadEntity = new()
            {
                IdSociedad = request.IdSociedad,
                NombreSociedad = request.NombreSociedad,
                UsuarioModifica = request.UsuarioModifica
            };

            await _sociedadRepository.EditarSociedad(editarSociedadEntity);

            return Unit.Value;
        }
    }
}
