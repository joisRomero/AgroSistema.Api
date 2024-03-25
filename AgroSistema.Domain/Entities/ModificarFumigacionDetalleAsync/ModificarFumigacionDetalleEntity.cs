using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarFumigacionDetalleAsync
{
    public class ModificarFumigacionDetalleEntity
    {
        public int? IdFumigacionDetalle { get; set; }
        public int? CantidadFumigacionDetalle { get; set; }
        public int? IdAgroquimico { get; set; }
        public int? UnidadFumigacionDetalle { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
