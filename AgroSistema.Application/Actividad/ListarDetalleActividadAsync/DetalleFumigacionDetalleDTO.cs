using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListarDetalleActividadAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarDetalleActividadAsync
{
    public class DetalleFumigacionDetalleDTO : IMapFrom<FumigacionDetalleActividadEntity>
    {
        public int IdFumigacionDetalle { get; set; }
        public int CantidadFumigacionDetalle { get; set; }
        public int UnidadDatoComunFumigacionDetalle { get; set; }
        public string? UnidadDescripcionFumigacionDetalle { get; set; }
        public int IdAgroQuimico { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FumigacionDetalleActividadEntity, DetalleFumigacionDetalleDTO>();
        }
    }
}
