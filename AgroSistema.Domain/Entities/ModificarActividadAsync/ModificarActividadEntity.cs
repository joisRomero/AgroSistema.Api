using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarActividadAsync
{
    public class ModificarActividadEntity
    {
        public int? IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public int? CantidadSemillaActividad { get; set; }
        public int? UnidadSemilla { get; set; }
        public int? IdCampania { get; set; }
        public int? IdTipoActividad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
