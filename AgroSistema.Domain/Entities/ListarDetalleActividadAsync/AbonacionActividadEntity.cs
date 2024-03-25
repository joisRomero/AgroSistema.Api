using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarDetalleActividadAsync
{
    public class AbonacionActividadEntity
    {
        public int IdAbonacion { get; set; }
        public int CantidadAbonacion { get; set; }
        public int UnidadDatoComunAbonacion { get; set; }
        public string? UnidadDescripcionAbonacion { get; set; }
        public int IdAbono { get; set; }
        public string? DescripcionAbono { get; set; }
    }
}
