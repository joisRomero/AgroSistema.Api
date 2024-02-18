using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EditarCampaniaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.EditarCampaniaAsync
{
    public class EditarCampaniaCommandHandler : IRequestHandler<EditarCampaniaCommand>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        public EditarCampaniaCommandHandler(ICampaniaRepository campaniaRepository)
        {
            _campaniaRepository = campaniaRepository;
        }

        public async Task<Unit> Handle(EditarCampaniaCommand request, CancellationToken cancellationToken)
        {
            EditarCampaniaEntity entity = new()
            {
                IdCampania = request.IdCampania,
                NombreTerreno = request.NombreTerreno,
                AreaSembrar = request.AreaSembrar,
                UnidadTerreno = request.UnidadTerreno,
                NombreCampania = request.NombreCampania,
                DescripcionCampania = request.DescripcionCampania,
                FechaInicio = request.FechaInicio,
                IdCultivo = request.IdCultivo,
                IdSociedad = request.IdSociedad,
                IdUsuario = request.IdUsuario,
                UsuarioModifica = request.UsuarioModifica,
            };

            await _campaniaRepository.EditarCampaniaAsync(entity);
            return Unit.Value;
        }
    }
}
