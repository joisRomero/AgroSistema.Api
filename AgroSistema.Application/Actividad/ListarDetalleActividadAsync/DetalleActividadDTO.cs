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
        public int? IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public int? IdTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public int CantidadSemilla { get; set; }
        public int UnidadSemilla { get; set; }
        public string? UnidadDescripcionSemilla { get; set; }
        public IEnumerable<DetalleTrabajadoresDTO>? ListaDetalleTrabajadores { get; set; }
        public IEnumerable<DetalleGastosDTO>? ListaDetalleGastos { get; set; }
        public IEnumerable<DetalleAbonacionDTO>? ListaDetalleAbonacion { get; set; }
        public IEnumerable<DetalleFumigacionDetalleDTO>? ListaDetalleFumigacionDetalle { get; set; }
        public int? CantidadFumigacion { get; set; }
        public int? UnidadDatoComunFumigacion { get; set; }
    }
}
