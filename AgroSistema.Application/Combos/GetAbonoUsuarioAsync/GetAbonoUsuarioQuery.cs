using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetAbonoUsuarioAsync
{
    public class GetAbonoUsuarioQuery : IRequest<IEnumerable<GetAbonoUsuarioQueryDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
