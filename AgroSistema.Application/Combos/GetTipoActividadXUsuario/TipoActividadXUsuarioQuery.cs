using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoActividadXUsuario
{
    public class TipoActividadXUsuarioQuery : IRequest<IEnumerable<TipoActividadXUsuarioDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
