using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync
{
    public class ListaPaginadaGastoDetalleEntity
    {
        public int IdCampania { get; set; }
        public int? IdTipoGasto { get; set; }
        public DateTime? FechaGasto { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
