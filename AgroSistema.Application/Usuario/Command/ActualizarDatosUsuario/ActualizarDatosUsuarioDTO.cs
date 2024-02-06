using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.ActualizarDatosUsuario;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ActualizarDatosUsuario
{
    public class ActualizarDatosUsuarioDTO : IMapFrom<ResponseDatosUsuarioEntity>
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Correo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ResponseDatosUsuarioEntity, ActualizarDatosUsuarioDTO>();
        }
    }
}
