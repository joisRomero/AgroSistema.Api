using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync
{
    public class ObtenerTipoGastoEntity
    {
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public string? Descripcion { get; set; }
    }
}
