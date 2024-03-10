using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.EliminarAbono
{
    public class EliminarAbonoCommand : IRequest
    {
        public int IdAbono { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
