using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync
{
    public class ListaPaginadaTipoActividadEntity
    {
        public int Correlativo { get; set; }
        public int IdTipoActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public int TotalRows { get; set; }
    }
}
