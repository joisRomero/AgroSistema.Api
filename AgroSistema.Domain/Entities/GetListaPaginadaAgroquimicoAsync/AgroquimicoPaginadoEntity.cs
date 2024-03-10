using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync
{
    public class AgroquimicoPaginadoEntity
    {
        public int Numero { get; set; }
        public int TotalRows { get; set; }
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? NombreTipoAgroquimico { get; set; }
    }
}