using AgroSistema.Application.Common.Mappings;
using AgroSistema.Application.Usuario.Query.ObtenerDatosUsuario;
using AgroSistema.Domain.Entities.CambiarClaveRecuperacionCuentaAsync;
using AgroSistema.Domain.Entities.ObtenerDatosUsuarioAsync;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.CambiarClaveRecuperacionCuenta
{
    public class CambiarClaveRecuperacionCuentaDTO : IMapFrom<CambiarClaveRecuperacionCuentaEntity>
    {
        public string? NombreUsuario { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CambiarClaveRecuperacionCuentaEntity, CambiarClaveRecuperacionCuentaDTO>();
        }
    }
}
