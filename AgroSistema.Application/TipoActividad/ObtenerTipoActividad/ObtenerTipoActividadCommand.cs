using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoActividad.ObtenerTipoActividad
{
    public class ObtenerTipoActividadCommand :IRequest<ObtenerTipoActividadDTO>
    {
        public int IdTipoActividad { get; set; }
    }
}
