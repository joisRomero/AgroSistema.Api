using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.ListarDetalleActividadAsync
{
    public class FumigacionDetalleActividadEntity
    {
        public int IdFumigacionDetalle { get; set; }
        public int CantidadFumigacionDetalle { get; set; }
        public int UnidadDatoComunFumigacionDetalle { get; set; }
        public string? UnidadDescripcionFumigacionDetalle { get; set; }
        public int IdAgroQuimico { get; set; }
    }
}
