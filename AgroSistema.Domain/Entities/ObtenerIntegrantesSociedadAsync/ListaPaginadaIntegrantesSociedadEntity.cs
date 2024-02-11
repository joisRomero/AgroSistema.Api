using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync
{
    public class ListaPaginadaIntegrantesSociedadEntity
    {
        public int IdSociedad { get; set; }
        public string? Nombre { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
