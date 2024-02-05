using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarCultivoAsync
{
    public class EliminarCultivoEntity
    {
        public int IdCultivo { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
