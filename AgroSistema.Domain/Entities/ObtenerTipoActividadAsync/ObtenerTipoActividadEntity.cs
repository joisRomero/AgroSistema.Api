using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ObtenerTipoActividadAsync
{
    public class ObtenerTipoActividadEntity
    {
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
    }
}
