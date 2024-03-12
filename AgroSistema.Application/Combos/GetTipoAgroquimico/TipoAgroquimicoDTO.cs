using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetTipoAgroquimicoAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoAgroquimico
{
    public class TipoAgroquimicoDTO : IMapFrom<GetTipoAgroquimicoEntity>
    {
        public string? Nombre { get; set; }
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetTipoAgroquimicoEntity, TipoAgroquimicoDTO>();
        }
    }
}
