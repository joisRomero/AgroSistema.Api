using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.CrearUsuarioAsync
{
    public class CrearUsuarioEntity
    {
        public string? NombreUsuario { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Correo { get; set; }
    }
}
