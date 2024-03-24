using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.EliminarTrabajadorListaAsync
{
    public class EliminarTrabajadorListaEntity
    {
        public int? IdActividad { get; set; }
        public string? XML_TrabajadorLista { get; set; }
        public string? UsuarioElimina { get; set; }     
    }
}
