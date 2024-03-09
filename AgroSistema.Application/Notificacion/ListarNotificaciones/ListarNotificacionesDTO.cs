using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.ListarNotificacionesAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Notificacion.ListarNotificaciones
{
    public class ListarNotificacionesDTO : IMapFrom<ListarNotificacionesEntity>
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListarNotificacionesEntity, ListarNotificacionesDTO>();
        }
    }
}
