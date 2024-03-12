using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync
{
    public class FumigacionDetalleRequestDTO
    {
        public int? IdFumigacionDetalle { get; set; }
        public int? CantidadFumigacionDetalle { get; set; }
        public int? UnidadFumigacionDetalle { get; set; }
        public int? IdAgroquimico { get; set; }
    }
}
