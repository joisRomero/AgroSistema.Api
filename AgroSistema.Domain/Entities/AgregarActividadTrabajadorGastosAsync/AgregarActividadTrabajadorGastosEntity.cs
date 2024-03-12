using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync
{
    public class AgregarActividadTrabajadorGastosEntity
    {
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public int? CantidadSemillaActividad { get; set; }
        public int? UnidadSemilla { get; set; }
        public int? IdCampania { get; set; }
        public int? IdTipoActividad { get; set; }
        public string? UsuarioInserta { get; set; }
        public string? XML_ListaTrabajadores { get; set; }
        public string? XML_ListaGastos { get; set; }
        public string? XML_Abonacion { get; set; }
        public int? CantidadFumigacion { get; set; }
        public int? UnidadFumigacion { get; set; }
        public string? XML_FumigacionDetalle { get; set; }
    }
}
