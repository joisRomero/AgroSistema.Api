using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AsignarAdministradorAsync
{
    public class AsignarAdministradorSociedadEntity
    {
        public int IdUsuario { get; set; }
        public int IdSociedad { get; set; }
        public string? UsuarioModifica { get; set; }
        public string? Accion { get; set; }
    }
}
