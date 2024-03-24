using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetAbonoUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAbonoUsuarioAsync
{
    public class GetAbonoUsuarioQueryDTO : IMapFrom<AbonoUsuarioEntity>
    {
        public int IdAbono { get; set; }
        public string? NombreAbono { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AbonoUsuarioEntity, GetAbonoUsuarioQueryDTO>();
        }
    }
}
