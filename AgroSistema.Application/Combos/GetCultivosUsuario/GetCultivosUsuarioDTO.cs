using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetCultivosUsuarioaAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetCultivosUsuario
{
    public class GetCultivosUsuarioDTO : IMapFrom<CultivosUsuarioEntity>
    {
        public int CodigoCultivosUsuario { get; set; }
        public String? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CultivosUsuarioEntity, GetCultivosUsuarioDTO>();
        }
    }
}
