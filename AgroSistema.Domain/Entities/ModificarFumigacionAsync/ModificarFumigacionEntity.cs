using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarFumigacionAsync
{
    public class ModificarFumigacionEntity
    {
        public int IdActividad { get; set; }
        public int CantidadFumigacion { get; set; }
        public int UnidadFumigacion { get; set; }
        public string UsuarioModifica { get; set; }
    }
}
