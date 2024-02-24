using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ListaPaginadaTipoActividad
{
    public class TipoActividadPaginadaDTO : IMapFrom<ListaPaginadaTipoActividadEntity>
    {
        public int Correlativo { get; set; }
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaPaginadaTipoActividadEntity, TipoActividadPaginadaDTO>();
        }
    }
}
