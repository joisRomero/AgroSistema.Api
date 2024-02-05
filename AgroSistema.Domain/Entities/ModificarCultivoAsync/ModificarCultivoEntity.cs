using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarCultivoAsync
{
    public class ModificarCultivoEntity
    {
        public int IdCultivo { get; set; }
        public string? NombreCultivo { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
