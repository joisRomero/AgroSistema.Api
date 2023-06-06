using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadesCosechaAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadesCosecha
{
    public class GetUnidadesCosechaDTO : IMapFrom<UnidadesCosechaEntity>
    {
        public int CodigoUnidadCosecha { get; set; }
        public String? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadesCosechaEntity, GetUnidadesCosechaDTO>();
        }
    }
}
