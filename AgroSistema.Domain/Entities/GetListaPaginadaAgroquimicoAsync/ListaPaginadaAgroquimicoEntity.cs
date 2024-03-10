using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync
{
    public class ListaPaginadaAgroquimicoEntity
    {
        public string? Nombre { get; set; }
        public int? IdTipoAgroquimico { get; set; }
        public int IdUsuario { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
