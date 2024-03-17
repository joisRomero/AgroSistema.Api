using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarCosechaAsync
{
    public class EliminarCosechaEntity
    {
        public int IdCosecha { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
