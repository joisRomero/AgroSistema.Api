using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarTipoActividadAsync
{
    public class EliminarTipoActividadEntity
    {
        public int IdTipoActividad { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
