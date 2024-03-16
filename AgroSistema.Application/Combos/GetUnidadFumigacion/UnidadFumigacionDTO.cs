using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadFumigacionAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadFumigacion
{
    public class UnidadFumigacionDTO : IMapFrom<UnidadFumigacionEntity>
    {
        public int CodigoUnidadFumigacion { get; set; }
        public string? DescripcionLarga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadFumigacionEntity, UnidadFumigacionDTO>();
        }
    }
}
