using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarDetalleActividadAsync
{
    public class GastoActividadEntity
    {
        public int IdGastoDetalle { get; set; }
        public string DescripcionGastoDetalle { get; set; }
        public int CantidadGastoDetalle { get; set; }
        public decimal CostoUnitarioGastoDetalle { get; set; }
        public decimal CostoTotalGastoDetalle { get; set; }
        public DateTime FechaGastoDetalle { get; set; }
        public int IdTipoGasto { get; set; }
        public string NombreTipoGasto { get; set; }
    }
}
