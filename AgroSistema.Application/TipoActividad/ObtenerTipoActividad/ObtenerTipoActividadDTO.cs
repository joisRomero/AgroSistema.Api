using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerTipoActividadAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ObtenerTipoActividad
{
    public class ObtenerTipoActividadDTO : IMapFrom<ObtenerTipoActividadEntity>
    {
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerTipoActividadEntity, ObtenerTipoActividadDTO>();
        }
    }
}
