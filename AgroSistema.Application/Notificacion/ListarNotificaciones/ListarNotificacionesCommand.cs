using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Notificacion.ListarNotificaciones
{
    public class ListarNotificacionesCommand : IRequest<IEnumerable<ListarNotificacionesDTO>>
    {
        public int IdUsuario { get; set; }
        public int IdCaso { get; set; }
    }
}
