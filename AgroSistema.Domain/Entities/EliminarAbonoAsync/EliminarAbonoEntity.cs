using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarAbonoAsync
{
    public class EliminarAbonoEntity
    {
        public int IdAbono { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
