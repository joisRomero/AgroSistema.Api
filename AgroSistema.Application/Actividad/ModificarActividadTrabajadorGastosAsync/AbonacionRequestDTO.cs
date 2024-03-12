using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync
{
    public class AbonacionRequestDTO
    {
        public int IdAbonacion { get; set; }
        public int CantidadAbonacion { get; set; }
        public int UnidadAbonacion { get; set; }
        public int? IdAbono { get; set; }
    }
}
