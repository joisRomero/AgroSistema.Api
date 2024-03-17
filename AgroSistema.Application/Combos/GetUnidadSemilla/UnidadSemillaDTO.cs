using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadSemillaAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadSemilla
{
    public class UnidadSemillaDTO : IMapFrom<UnidadSemillaEntity>
    {
        public int CodigoUnidadSemilla { get; set; }
        public string? DescripcionLarga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadSemillaEntity, UnidadSemillaDTO>();
        }
    }
}
