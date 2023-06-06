using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync
{
    public class ListaPaginadaCosechasEntity
    {
        public int IdCampania { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
