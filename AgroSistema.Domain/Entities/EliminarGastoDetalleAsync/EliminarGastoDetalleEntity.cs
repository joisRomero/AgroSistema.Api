using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarGastoDetalleAsync
{
    public class EliminarGastoDetalleEntity
    {
        public int IdGastoDetalle { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
