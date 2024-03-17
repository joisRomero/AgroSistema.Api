using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.ObtenerCosecha
{
    public class ObtenerCosechaDTO
    {
        public int IdCosecha { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCampania { get; set; }
        public IEnumerable<DetalleCosechaDetalleDTO>? ListaDetalleCosecha { get; set; }
    }
}
