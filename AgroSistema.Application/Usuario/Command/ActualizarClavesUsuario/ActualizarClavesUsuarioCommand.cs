using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ActualizarClavesUsuario
{
    public class ActualizarClavesUsuarioCommand : IRequest<ActualizarClavesUsuarioDTO>
    {
        public int IdUsuario { get; set; }
        public string? ClaveActual { get; set; }
        public string? ClaveNueva { get; set; }
    }
}
