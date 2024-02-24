using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarTipoGastoAsync
{
    public class EliminarTipoGastoEntity
    {
        public int IdTipoGasto { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
