using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadFumigacionDetalleAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadFumigacionDetalle
{
    public class UnidadFumigacionDetalleDTO : IMapFrom<UnidadFumigacionDetalleEntity>
    {
        public int CodigoUnidadFumigacionDetalle { get; set; }
        public string? DescripcionLarga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadFumigacionDetalleEntity, UnidadFumigacionDetalleDTO>();
        }
    }
}
