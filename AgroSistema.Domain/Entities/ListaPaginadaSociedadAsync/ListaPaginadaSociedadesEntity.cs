using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaSociedadAsync
{
    public class ListaPaginadaSociedadesEntity
    {
        public int Correlativo { get; set; }
        public int IdSociedad { get; set; }
        public string? NombreSociedad { get; set; }
        public string? Estado { get; set; }
        public string? NombreUsuario { get; set; }
        public int CantidadRegistros { get; set; }
    }
}
