using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.RegistrarTipoActividadAsync
{
    public class RegistrarTipoActividadEntity
    {
        public string? NombreTipoActividad { get; set; }
        public string? RealizadaPorTipoActividad { get; set; }
        public string? DescripcionTipoActividad { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
