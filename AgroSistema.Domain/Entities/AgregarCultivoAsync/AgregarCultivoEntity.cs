using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarCultivoAsync
{
    public class AgregarCultivoEntity
    {
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? CodUsuario { get; set; }
    }
}
