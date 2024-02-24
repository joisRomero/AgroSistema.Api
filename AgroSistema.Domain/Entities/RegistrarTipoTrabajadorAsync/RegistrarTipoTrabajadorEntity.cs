using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.RegistrarTipoTrabajadorAsync
{
    public class RegistrarTipoTrabajadorEntity
    {
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
