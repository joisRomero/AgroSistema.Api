using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarDetalleActividadAsync
{
    public class TrabajadorActividadEntity
    {
        public int IdTrabajador { get; set; }
        public string DescripcionTrabajador { get; set; }
        public int CantidadTrabajador { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string DescripcionTipoTrabajador { get; set; }
    }
}
