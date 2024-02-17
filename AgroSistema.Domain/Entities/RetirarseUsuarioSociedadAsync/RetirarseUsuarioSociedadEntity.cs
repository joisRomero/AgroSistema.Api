using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.RetirarseUsuarioSociedadAsync
{
    public class RetirarseUsuarioSociedadEntity
    {
        public int IdUsuario { get; set; }
        public int IdSociedad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
