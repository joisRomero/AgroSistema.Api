using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarAgroquimicoAsync
{
    public class EliminarAgroquimicoEntity
    {
        public int IdAgroquimico { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
