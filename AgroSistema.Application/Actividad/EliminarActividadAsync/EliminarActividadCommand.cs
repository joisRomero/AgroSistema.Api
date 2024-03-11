using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.EliminarActividadAsync
{
    public class EliminarActividadCommand : IRequest
    {
        public int IdActividad { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
