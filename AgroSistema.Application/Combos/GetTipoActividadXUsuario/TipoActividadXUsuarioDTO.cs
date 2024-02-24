using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetTipoActividadXUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoActividadXUsuario
{
    public class TipoActividadXUsuarioDTO : IMapFrom<TipoActividadXUsuarioEntity>
    {
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoActividadXUsuarioEntity,TipoActividadXUsuarioDTO>();
        }
    }
}
