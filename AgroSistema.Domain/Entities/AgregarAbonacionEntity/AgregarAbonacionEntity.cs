using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarAbonacionEntity
{
    public class AgregarAbonacionEntity
    {
        public int? IdActividad { get; set; }
        public int? CantidadAbonacion { get; set; }
        public int? UnidadAbonacion { get; set; }
        public int? IdAbono { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
