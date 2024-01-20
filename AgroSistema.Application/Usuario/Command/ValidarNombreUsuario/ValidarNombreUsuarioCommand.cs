using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarUsuario
{
    public class ValidarNombreUsuarioCommand : IRequest<ValidarNombreUsuarioDTO>
    {
        public string? NombreUsuario { get; set; }
    }
}
