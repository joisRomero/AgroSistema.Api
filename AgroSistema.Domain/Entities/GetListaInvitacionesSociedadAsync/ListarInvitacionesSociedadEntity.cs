using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync
{
    public class ListarInvitacionesSociedadEntity
    {
        public int IdInvitacion { get; set; }
        public string? NombreEmisor { get; set; }
        public string? NombreSociedad { get; set; }
    }
}
