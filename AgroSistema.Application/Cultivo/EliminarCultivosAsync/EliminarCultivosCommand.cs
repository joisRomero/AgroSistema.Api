using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.EliminarCultivosAsync
{
    public class EliminarCultivosCommand : IRequest
    {
        public int IdCultivo { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
