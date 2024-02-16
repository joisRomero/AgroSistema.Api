using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.RegistrarInvitacionSociedadAsync
{
    public class RegistrarInvitacionSociedadEntity
    {
        public int IdEmisor { get; set; }
        public int IdReceptor { get; set; }
        public int IdSociedad { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
