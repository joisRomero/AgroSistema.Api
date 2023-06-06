using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync
{
    public class CosechaPaginadaEntity
    {
        public int Numero { get; set; }
        public int IdCosecha { get; set; }
        public string? Fecha { get; set; }
        public string? Descripcion { get; set; }
    }
}
