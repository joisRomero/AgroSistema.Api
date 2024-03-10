using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarAgroquimicoAsync
{
    public class AgregarAgroquimicoEntity
    {
        public string? NombreAgroquimico { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
