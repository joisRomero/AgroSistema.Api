using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarAbonacionListaAsync
{
    public class EliminarAbonacionListaEntity
    {
        public int? IdActividad { get; set; }
        public string? XML_AbonacionLista { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
