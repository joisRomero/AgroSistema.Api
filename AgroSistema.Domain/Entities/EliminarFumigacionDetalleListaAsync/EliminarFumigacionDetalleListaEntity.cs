using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarFumigacionDetalleListaAsync
{
    public class EliminarFumigacionDetalleListaEntity
    {
        public int? IdActividad { get; set; }
        public string? XML_FumigacionDetalleLista { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
