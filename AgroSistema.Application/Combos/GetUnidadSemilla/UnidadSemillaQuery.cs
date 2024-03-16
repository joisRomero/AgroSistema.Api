using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetUnidadSemilla
{
    public class UnidadSemillaQuery : IRequest<IEnumerable<UnidadSemillaDTO>>
    {
    }
}
