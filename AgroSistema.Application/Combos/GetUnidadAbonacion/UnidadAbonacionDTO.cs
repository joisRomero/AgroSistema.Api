using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.GetUnidadAbonacionAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadAbonacion
{
    public class UnidadAbonacionDTO : IMapFrom<UnidadAbonacionEntity>
    {
        public int CodigoUnidadAbonacion { get; set; }
        public string? DescripcionLarga { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadAbonacionEntity, UnidadAbonacionDTO>();
        }
    }
}
