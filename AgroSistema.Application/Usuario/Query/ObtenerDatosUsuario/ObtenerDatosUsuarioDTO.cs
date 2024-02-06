using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ObtenerDatosUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.ObtenerDatosUsuario
{
    public class ObtenerDatosUsuarioDTO : IMapFrom<ObtenerDatosUsuarioEntity>
    {
        public string? Correo { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<ObtenerDatosUsuarioEntity, ObtenerDatosUsuarioDTO>();
        }
    }
}
