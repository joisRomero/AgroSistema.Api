using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.EliminarTipoActividad
{
    public class EliminarTipoActividadCommand : IRequest
    {
        public int IdTipoActividad { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
