using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.EliminarCultivoAsync;
using AgroSistema.Domain.Entities.EliminarSociedadAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.EliminarSociedad
{
    public class EliminarSociedadCommandHandler : IRequestHandler<EliminarSociedadCommand>
    {
        private readonly ISociedadRepository _sociedadRepository;

        public EliminarSociedadCommandHandler(ISociedadRepository sociedadRepository)
        {
            _sociedadRepository = sociedadRepository;
        }

        public async Task<Unit> Handle(EliminarSociedadCommand request, CancellationToken cancellationToken)
        {
            EliminarSociedadEntity eliminarSociedadEntity = new()
            {
                IdSociedad = request.IdSociedad,
                UsuarioElimina = request.UsuarioElimina
            };


            await _sociedadRepository.EliminarSociedad(eliminarSociedadEntity);

            return Unit.Value;
        }
    }
}
