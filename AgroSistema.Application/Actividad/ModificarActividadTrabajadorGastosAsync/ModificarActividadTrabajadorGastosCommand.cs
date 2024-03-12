using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ModificarActividadTrabajadorGastosAsync
{
    public class ModificarActividadTrabajadorGastosCommand : IRequest
    {
        public int? IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public int? CantidadSemillaActividad { get; set; }
        public int? UnidadSemilla { get; set; }
        public int? IdCampania { get; set; }
        public int? IdTipoActividad { get; set; }
        public string? UsuarioModifica { get; set; }
        public IEnumerable<TrabajadorRequestDTO>? ListaTrabajador { get; set; }
        public IEnumerable<GastoRequestDTO>? ListaGasto { get; set; }
        public IEnumerable<AbonacionRequestDTO>? ListaAbonacion { get; set; }
        public int? CantidadFumigacion { get; set; }
        public int? UnidadFumigacion { get; set; }
        public IEnumerable<FumigacionDetalleRequestDTO>? ListaFumigacionDetalle { get; set; }

    }
}
