using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarNotificacionesAsync
{
    public class ListarNotificacionesRequestEntity
    {
        public int IdUsuario { get; set; }
        public string? IdCaso { get; set; }
    }
}
