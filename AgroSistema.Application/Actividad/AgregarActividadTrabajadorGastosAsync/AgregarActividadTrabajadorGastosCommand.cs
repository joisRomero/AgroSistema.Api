using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AgroSistema.Application.Actividad.AgregarActividadTrabajadorGastosAsync
{
    public class AgregarActividadTrabajadorGastosCommand : IRequest
    {
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public int CantidadSemillaActividad { get; set; }
        public int UnidadSemilla { get; set; }
        public int IdCampania { get; set; }
        public int IdTipoActividad { get; set; }
        public string? UsuarioInserta { get; set; }
        public IEnumerable<TrabajadorDTO>? ListaTrabajadores { get; set; }
        public IEnumerable<GastoDTO>? ListaGastos{ get; set; }
        public IEnumerable<AbonacionDTO>? ListaAbonacion { get; set; }
        public int CantidadFumigacion { get; set; }
        public int UnidadFumigacion { get; set; }
        public IEnumerable<FumigacionDetalleDTO>? ListaFumigacionDetalle { get; set; }

    }
}
