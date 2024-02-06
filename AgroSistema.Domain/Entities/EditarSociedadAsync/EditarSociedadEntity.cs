using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EditarSociedadAsync
{
    public class EditarSociedadEntity
    {
        public int IdSociedad { get; set; }
        public string? NombreSociedad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
