﻿using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync
{
    public class ListarInvitacionesSociedadQueryHandler : IRequestHandler<ListarInvitacionesSociedadQuery, IEnumerable<ListarInvitacionesSociedadDTO>>
    {
        //private readonly IInvitacionRepository _invitacionRepository;
        private readonly IMapper _mapper;
        //public ListarInvitacionesSociedadQueryHandler(IInvitacionRepository invitacionRepository, IMapper mapper)
        public ListarInvitacionesSociedadQueryHandler(IMapper mapper)

        {
            //_invitacionRepository = invitacionRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ListarInvitacionesSociedadDTO>> Handle(ListarInvitacionesSociedadQuery request, CancellationToken cancellationToken)
        {
            RequestListarInvitacionesSociedadEntity entity = new RequestListarInvitacionesSociedadEntity()
            {
                IdUsuario = request.IdUsuario
            };

            //var result = await _invitacionRepository.ListarInvitacionesSociedadAsync(entity);
            throw new NotImplementedException();

            //return entity;
        }
    }
}
