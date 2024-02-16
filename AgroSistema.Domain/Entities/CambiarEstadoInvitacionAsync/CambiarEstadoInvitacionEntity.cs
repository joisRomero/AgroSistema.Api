using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.CambiarEstadoInvitacionAsync
{
    public class CambiarEstadoInvitacionEntity
    {
        public int IdInvitacion { get; set; }
        public char Accion { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
