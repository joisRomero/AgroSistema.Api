using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.CrearUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.CrearUsuario
{
    public class CrearUsuarioDTO : IMapFrom<ResponseCrearUsuarioEntity>
    {
        public int IdUsuario { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ResponseCrearUsuarioEntity, CrearUsuarioDTO>();
        }
    }
}
