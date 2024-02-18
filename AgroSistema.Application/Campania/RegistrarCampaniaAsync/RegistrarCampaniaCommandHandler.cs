using AgroSistema.Application.Campania.RegistrarCamapaniaAsync;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.RegistrarCampaniaAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Campania.RegistrarCampaniaAsync
{
    public class RegistrarCampaniaCommandHandler : IRequestHandler<RegistrarCampaniaCommand>
    {
        private readonly ICampaniaRepository _campaniaRepository;
        //private readonly IMapper _mapper;
        public RegistrarCampaniaCommandHandler(ICampaniaRepository campaniaRepository)
        {
            _campaniaRepository = campaniaRepository;
        }

        public async Task<Unit> Handle(RegistrarCampaniaCommand request, CancellationToken cancellationToken)
        {
            RegistrarCampaniaEntity entity = new()
            {
                NombreTerreno = request.NombreTerreno,
                AreaSembrar = request.AreaSembrar,
                UnidadTerreno = request.UnidadTerreno,
                NombreCampania = request.NombreCampania,
                DescripcionCampania = request.DescripcionCampania,
                FechaInicio = request.FechaInicio,
                IdCultivo = request.IdCultivo,
                IdSociedad = request.IdSociedad,
                IdUsuario = request.IdUsuario,
                UsuarioInserta = request.UsuarioInserta,
            };

            await _campaniaRepository.RegistrarCampaniaAsync(entity);

            return Unit.Value;
        }
    }
}
