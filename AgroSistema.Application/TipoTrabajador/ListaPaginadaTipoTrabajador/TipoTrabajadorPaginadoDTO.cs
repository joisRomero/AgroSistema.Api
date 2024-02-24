using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ListaPaginadaTipoTrabajador
{
    public class TipoTrabajadorPaginadoDTO : IMapFrom<ListaPaginadaTipoTrabajadorEntity>
    {
        public int Correlativo { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListaPaginadaTipoTrabajadorEntity, TipoTrabajadorPaginadoDTO>();
        }
    }
}
