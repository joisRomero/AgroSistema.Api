using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ModificarAbonacionAsync
{
    public class ModificarAbonacionEntity
    {
        public int IdAbonacion { get; set; }
        public int CantidadAbonacion { get; set; }
        public int UnidadAbonacion { get; set; }
        public int? IdAbono { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
