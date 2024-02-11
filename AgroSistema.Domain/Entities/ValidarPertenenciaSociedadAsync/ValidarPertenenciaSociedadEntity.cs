using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ValidarPertenenciaSociedadAsync
{
    public class ValidarPertenenciaSociedadEntity
    {
        public int Respuesta { get; set; }
        public bool EsAdministrador { get; set; }
        public string? NombreSociedad { get; set; }
    }
}
