using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadesCampania
{
    public class GetUnidadesCampaniaQuery : IRequest<IEnumerable<GetUnidadesCampaniaDTO>>
    {
    }
}
