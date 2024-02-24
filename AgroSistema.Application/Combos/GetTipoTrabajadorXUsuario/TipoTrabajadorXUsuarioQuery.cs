using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoTrabajadorXUsuario
{
    public class TipoTrabajadorXUsuarioQuery : IRequest<IEnumerable<TipoTrabajadorXUsuarioDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
