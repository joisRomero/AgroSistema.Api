using AgroSistema.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarDetalleActividadAsync
{
    public class DetalleActividadDTO
    {
        public int IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public int IdTipoActividad { get; set; }
        public string DescripcionTipoActividad { get; set; }
        public IEnumerable<DetalleTrabajadoresDTO> ListaDetalleTrabajadores { get; set; }
        public IEnumerable<DetalleGastosDTO> LsitaDetalleGastos { get; set; }
    }
}
