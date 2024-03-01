using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarCorreoUnico
{
    public class ValidarCorreoUnicoCommand : IRequest<ValidarCorreoUnicoDTO>
    {
        public string Correo { get; set; }
    }
}
