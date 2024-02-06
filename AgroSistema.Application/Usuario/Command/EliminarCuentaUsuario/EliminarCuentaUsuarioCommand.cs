using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.EliminarCuentaUsuario
{
    public class EliminarCuentaUsuarioCommand : IRequest
    {
        public int IdUsuario { get; set; }
    }
}
