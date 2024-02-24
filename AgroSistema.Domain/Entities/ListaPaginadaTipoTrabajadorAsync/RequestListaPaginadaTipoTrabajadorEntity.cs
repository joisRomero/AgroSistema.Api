using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync
{
    public class RequestListaPaginadaTipoTrabajadorEntity
    {
        public string? NombreTipoTrabajador { get; set; }
        public int IdUsuario { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
