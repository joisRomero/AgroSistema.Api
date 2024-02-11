using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadesCampaniaAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadesCampania
{
    public class GetUnidadesCampaniaDTO : IMapFrom<UnidadesCampaniaEntity>
    {
        public int CodigoUnidadCampania { get; set; }
        public String? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadesCampaniaEntity, GetUnidadesCampaniaDTO>();
        }
    }
}
