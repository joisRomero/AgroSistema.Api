using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ValidarPertenenciaSociendad
{
    public class ValidarPertenenciaSociendadDTO
    {
        public bool Respuesta { get; set; }
        public bool EsAdministrador { get; set; }
        public string? NombreSociedad { get; set; }
    }
}
