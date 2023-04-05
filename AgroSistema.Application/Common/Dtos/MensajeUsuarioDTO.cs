using AutoMapper;
using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Dtos
{
    public class MensajeUsuarioDTO : IMapFrom<MensajeUsuarioEntity>
    {
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MensajeUsuarioEntity, MensajeUsuarioDTO>();
        }
    }
}
