using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarDetalleActividadAsync
{
    public class ListarDetalleActividadEntity
    {
        public int IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public int IdTipoActividad { get; set; }
        public string DescripcionTipoActividad { get; set; }
    }
}
