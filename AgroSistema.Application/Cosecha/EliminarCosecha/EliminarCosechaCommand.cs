using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.EliminarCosecha
{
    public class EliminarCosechaCommand : IRequest
    {
        public int IdCosecha { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
