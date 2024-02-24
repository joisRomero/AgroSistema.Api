using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetTipoTrabajadorXUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoTrabajadorXUsuario
{
    public class TipoTrabajadorXUsuarioDTO : IMapFrom<TipoTrabajadorXUsuarioEntity>
    {
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoTrabajadorXUsuarioEntity,TipoTrabajadorXUsuarioDTO>();
        }
    }
}
