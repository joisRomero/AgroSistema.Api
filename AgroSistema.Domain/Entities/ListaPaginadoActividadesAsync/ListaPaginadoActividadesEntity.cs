using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadoActividadesAsync
{
    public class ListaPaginadoActividadesEntity
    {
        public int Correlativo { get; set; }
        public int IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public string? DescripcionActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public decimal TotalGasto { get; set; }
        public int TotalRows { get; set; }
    }
}
