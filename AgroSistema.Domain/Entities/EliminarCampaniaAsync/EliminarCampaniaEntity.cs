using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarCampaniaAsync
{
    public class EliminarCampaniaEntity
    {
        public int IdCampania { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
