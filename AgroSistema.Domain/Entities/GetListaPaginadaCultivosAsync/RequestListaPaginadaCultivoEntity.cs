using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync
{
    public class RequestListaPaginadaCultivoEntity
    {
        public string? NombreCultivo { get; set; }
        public int? IdUsuario { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
