using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync
{
    public class ListaPaginadaCultivoEntity
    {
        public int Correlativo { get; set; }
        public string? NombreCultivo { get; set; }
        public string? Estado { get; set; }
        public string? NombreUsuario { get; set; }
        public int CantidadRegistros { get; set; }
    }
}
