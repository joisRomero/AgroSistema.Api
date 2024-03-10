using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.GetAbono
{
    public class ObtenerAbonoCommand : IRequest<ObtenerAbonoDTO>
    {
        public int IdAbono { get; set; }

    }
}
