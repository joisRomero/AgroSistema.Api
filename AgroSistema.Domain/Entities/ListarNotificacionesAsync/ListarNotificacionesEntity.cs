using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarNotificacionesAsync
{
    public class ListarNotificacionesEntity
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
