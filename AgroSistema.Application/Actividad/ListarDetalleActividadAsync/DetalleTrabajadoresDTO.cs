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
    public class DetalleTrabajadoresDTO : IMapFrom<TrabajadorActividadEntity>
    {
        public int IdTrabajador { get; set; }
        public string DescripcionTrabajador { get; set; }
        public int CantidadTrabajador { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string DescripcionTipoTrabajador { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrabajadorActividadEntity, DetalleTrabajadoresDTO>();
        }
    }
}
