using AgroSistema.Application.Combos.GetUnidadFumigacion;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.ReabrirCampaniaAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.ReabrirCampaniaAsync
{
    public class ReabrirCampaniaCommandHandler : IRequestHandler<ReabrirCampaniaCommand>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        private readonly IMapper _mapper;
        public ReabrirCampaniaCommandHandler(ICampaniaRepository campaniaRepository, IMapper mapper)
        {
            _campaniaRepository = campaniaRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ReabrirCampaniaCommand request, CancellationToken cancellationToken)
        {
            ReabrirCampaniaEntity entity = new()
            {
                IdCampania = request.IdCampania,
                UsuarioModifica = request.UsuarioModifica
            };

            await _campaniaRepository.ReabrirCampaniaAsync(entity);

            return Unit.Value;
        }
    }
}
