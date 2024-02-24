using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync
{
    public class ObtenerTipoTrabajadorEntity
    {
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
    }
}
