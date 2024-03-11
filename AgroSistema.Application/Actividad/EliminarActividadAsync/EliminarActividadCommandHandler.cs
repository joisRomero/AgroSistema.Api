using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarActividadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.EliminarActividadAsync
{
    public class EliminarActividadCommandHandler : IRequestHandler<EliminarActividadCommand>
    {
        private readonly IActividadRepository _actividadRepository;
        public EliminarActividadCommandHandler(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<Unit> Handle(EliminarActividadCommand request, CancellationToken cancellationToken)
        {
            EliminarActividadEntity eliminarActividadEntity = new()
            {
                IdActividad = request.IdActividad,
                UsuarioElimina = request.UsuarioElimina,
            };


            return Unit.Value;
        }
    }
}
