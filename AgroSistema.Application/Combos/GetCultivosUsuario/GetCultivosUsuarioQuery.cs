using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetCultivosUsuario
{
    public class GetCultivosUsuarioQuery : IRequest<IEnumerable<GetCultivosUsuarioDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
