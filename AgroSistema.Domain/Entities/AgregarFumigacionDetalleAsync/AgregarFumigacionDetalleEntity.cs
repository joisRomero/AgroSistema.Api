using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarFumigacionDetalleAsync
{
    public class AgregarFumigacionDetalleEntity
    {
        public int? IdFumigacion { get; set; }
        public int? CantidadFumigacionDetalle { get; set; }
        public int? UnidadFumigacionDetalle { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
