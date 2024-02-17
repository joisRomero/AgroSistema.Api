using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Query.CambiarClaveRecuperacionCuenta
{
    public class CambiarClaveRecuperacionCuentaQuery : IRequest<CambiarClaveRecuperacionCuentaDTO>
    {
        public string? Clave { get; set; }
        public string? Correo { get; set; }
    }
}
