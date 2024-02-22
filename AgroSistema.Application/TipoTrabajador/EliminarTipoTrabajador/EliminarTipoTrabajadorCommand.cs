using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.EliminarTipoTrabajador
{
    public class EliminarTipoTrabajadorCommand : IRequest
    {
        public int IdTipoTrabajador { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
