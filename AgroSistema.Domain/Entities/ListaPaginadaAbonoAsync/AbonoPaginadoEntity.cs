using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaAbonoAsync
{
    public class AbonoPaginadoEntity
    {
        public int Numero { get; set; }
        public int TotalRows { get; set; }
        public int IdAbono { get; set; }
        public string? NombreAbono { get; set; }
        public string? Descripcion { get; set; }

    }
}
