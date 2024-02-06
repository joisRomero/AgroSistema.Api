using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.ObtenerDatosUsuario
{
    public class ObtenerDatosUsuarioQuery : IRequest<ObtenerDatosUsuarioDTO>
    {
        public int IdUsuario { get; set; }
    }
}
