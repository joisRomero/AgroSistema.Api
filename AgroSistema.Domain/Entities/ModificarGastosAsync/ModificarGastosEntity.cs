using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarGastosAsync
{
    public class ModificarGastosEntity
    {
        public int? IdGasto { get; set; }
        public string? DescripcionGasto { get; set; }
        public int CantidadGasto { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaGasto { get; set; }
        public int IdTipoGasto { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
