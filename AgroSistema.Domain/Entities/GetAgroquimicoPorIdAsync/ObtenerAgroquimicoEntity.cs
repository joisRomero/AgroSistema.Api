using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetAgroquimicoPorIdAsync
{
    public class ObtenerAgroquimicoEntity
    {
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? NombreTipoAgroquimico { get; set; }
    }
}
