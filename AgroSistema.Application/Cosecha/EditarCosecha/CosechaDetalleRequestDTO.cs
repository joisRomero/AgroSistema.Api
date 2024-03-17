using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.EditarCosecha
{
    public class CosechaDetalleRequestDTO
    {
        public int? IdCosechaDetalle { get; set; }
        public int Cantidad { get; set; }
        public int Unidad { get; set; }
        public int Calidad { get; set; }
        public string? Descripcion { get; set; }
    }
}
