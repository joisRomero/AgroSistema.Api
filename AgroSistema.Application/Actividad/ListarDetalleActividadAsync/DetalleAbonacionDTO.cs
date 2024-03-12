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
    public class DetalleAbonacionDTO : IMapFrom<AbonacionActividadEntity>
    {
        public int IdAbonacion { get; set; }
        public int CantidadAbonacion { get; set; }
        public int UnidadDatoComunAbonacion { get; set; }
        public string? UnidadDescripcionAbonacion { get; set; }
        public int IdAbono { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AbonacionActividadEntity, DetalleAbonacionDTO>();
        }
    }
}
