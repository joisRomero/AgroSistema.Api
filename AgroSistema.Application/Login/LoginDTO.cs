using AutoMapper;
using AgroSistema.Application.Common.Mappings;
using AgroSistema.Domain.Entities.LoginAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Login
{
    public class LoginDTO : IMapFrom<LoginEntity>
    {
        public string? IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginEntity, LoginDTO>();
        }
    }
}
