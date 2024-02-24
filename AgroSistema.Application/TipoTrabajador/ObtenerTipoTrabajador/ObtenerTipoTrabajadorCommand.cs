using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ObtenerTipoTrabajador
{
    public class ObtenerTipoTrabajadorCommand : IRequest<TipoTrabajadorDTO>
    {
        public int IdTipoTrabajador { get; set; }
    }
}
