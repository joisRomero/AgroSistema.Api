using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAgroquimicoUsuarioAsync
{
    public class GetAgroquimicoUsuarioQuery : IRequest<IEnumerable<GetAgroquimicoUsuarioDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
