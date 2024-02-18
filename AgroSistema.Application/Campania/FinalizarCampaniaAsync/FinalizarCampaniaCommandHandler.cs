using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.FinalizarCampaniaAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.FinalizarCampaniaAsync
{
    public class FinalizarCampaniaCommandHandler : IRequestHandler<FinalizarCampaniaCommand>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        public FinalizarCampaniaCommandHandler(ICampaniaRepository campaniaRepository)
        {
            _campaniaRepository = campaniaRepository;
        }

        public async Task<Unit> Handle(FinalizarCampaniaCommand request, CancellationToken cancellationToken)
        {
            FinalizarCampaniaEntity entity = new()
            {
                IdCampania = request.IdCampania,
                FechaFinaliza = request.FechaFinaliza,
                UsuarioModifica = request.UsuarioModifica,
            };

            await _campaniaRepository.FinalizarCampaniaAsync(entity);
            
            return  Unit.Value;

        }
    }
}
