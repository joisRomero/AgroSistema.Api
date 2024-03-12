using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoAgroquimico
{
    public class TipoAgroquimicoQuery : IRequest<IEnumerable<TipoAgroquimicoDTO>>
    {
    }
}
