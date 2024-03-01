using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetTipoGastoXUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoGastoXUsuario
{
    public class TipoGastoXUsuarioDTO : IMapFrom<TipoGastoXUsuarioEntity>
    {
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoGastoXUsuarioEntity, TipoGastoXUsuarioDTO>();
        }
    }
}
