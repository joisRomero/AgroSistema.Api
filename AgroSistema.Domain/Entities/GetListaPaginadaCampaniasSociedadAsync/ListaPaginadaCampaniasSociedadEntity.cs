using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync
{
    public class ListaPaginadaCampaniasSociedadEntity
    {
        public int IdSociedad { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
