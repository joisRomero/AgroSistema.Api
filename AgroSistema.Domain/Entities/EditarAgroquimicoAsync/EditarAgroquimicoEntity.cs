using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EditarAgroquimicoAsync
{
    public class EditarAgroquimicoEntity
    {
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
