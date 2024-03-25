using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarGastoDetalleListaAsync
{
    public class EliminarGastoDetalleListaEntity
    {
        public int? IdActividad { get; set; }
        public string? XML_GastoDetalleLista { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
