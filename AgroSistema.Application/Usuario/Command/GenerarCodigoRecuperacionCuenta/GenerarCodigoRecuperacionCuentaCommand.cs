using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.GenerarCodigoRecuperacionCuenta
{
    public class GenerarCodigoRecuperacionCuentaCommand : IRequest
    {
        public string? Correo { get; set; }
    }
}
