using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync
{
    public class ListaPaginadaTipoTrabajadorEntity
    {
        public int Correlativo { get; set; }
        public int IdTipoTrabajador { get; set; }
        public string? NombreTipoTrabajador { get; set; }
        public string? DescripcionTipoTrabajador { get; set; }
        public int TotalRows { get; set; }
    }
}
