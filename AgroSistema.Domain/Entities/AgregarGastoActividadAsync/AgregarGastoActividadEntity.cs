using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarGastoActividadAsync
{
    public class AgregarGastoActividadEntity
    {
        public string? DescripcionGasto { get; set; }
        public int CantidadGasto { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaGasto { get; set; }
        public int IdTipoGasto { get; set; }
        public int? IdActividad { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
