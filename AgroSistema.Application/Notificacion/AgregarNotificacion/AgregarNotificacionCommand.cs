using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Notificacion.AgregarNotificacion
{
    public class AgregarNotificacionCommand : IRequest
    {
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
