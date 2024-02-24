using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync
{
    public class TipoGastoPaginadoEntity
    {
        public int Numero { get; set; }
        public int TotalRows { get; set; }
        public int IdTipoGasto { get; set; }
        public string? NombreTipoGasto { get; set; }
        public string? Descripcion { get; set; }
    }
}
