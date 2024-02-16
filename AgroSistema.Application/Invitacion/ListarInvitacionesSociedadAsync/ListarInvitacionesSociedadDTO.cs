using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync
{
    public class ListarInvitacionesSociedadDTO : IMapFrom<ListarInvitacionesSociedadEntity>
    {
        public int IdInvitacion { get; set; }
        public string? NombreEmisor { get; set; }
        public string? NombreSociedad { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ListarInvitacionesSociedadEntity, ListarInvitacionesSociedadDTO>();
        }
    }
}
