using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetAgroquimicoUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAgroquimicoUsuarioAsync
{
    public class GetAgroquimicoUsuarioDTO : IMapFrom<AgroquimicoUsuarioEntity>
    {
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgroquimicoUsuarioEntity, GetAgroquimicoUsuarioDTO>();
        }
    }
}
