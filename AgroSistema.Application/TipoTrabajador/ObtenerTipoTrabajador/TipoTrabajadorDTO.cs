using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ObtenerTipoTrabajador
{
    public class TipoTrabajadorDTO : IMapFrom<ObtenerTipoTrabajadorEntity>
    {
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerTipoTrabajadorEntity, TipoTrabajadorDTO>();
        }
    }
}
