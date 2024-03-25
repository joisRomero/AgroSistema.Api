using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListaPaginadoActividadesAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarActividadesPaginadoAsync
{
    public class ActividadesPaginadoDTO : IMapFrom<ListaPaginadoActividadesEntity>
    {
        public int Correlativo { get; set; }
        public int IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public decimal TotalGasto { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaPaginadoActividadesEntity, ActividadesPaginadoDTO>();
        }
    }
}
