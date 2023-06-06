using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetCalidadesCosecha
{
    public class GetCalidadesCosechaDTO : IMapFrom<CalidadesCosechaEntity>
    {
        public int CodigoCalidadCosecha { get; set; }
        public String? Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CalidadesCosechaEntity, GetCalidadesCosechaDTO>();
        }
    }
}
