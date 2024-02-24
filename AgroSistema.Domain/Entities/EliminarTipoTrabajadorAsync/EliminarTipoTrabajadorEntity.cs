using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarTipoTrabjadorAsync
{
    public class EliminarTipoTrabajadorEntity
    {
        public int IdTipoTrabajador { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
