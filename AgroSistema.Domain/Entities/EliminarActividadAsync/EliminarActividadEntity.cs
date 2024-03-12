using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarActividadAsync
{
    public class EliminarActividadEntity
    {
        public int IdActividad { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
