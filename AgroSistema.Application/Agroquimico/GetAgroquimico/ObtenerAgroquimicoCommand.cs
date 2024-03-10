using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.GetAgroquimico
{
    public class ObtenerAgroquimicoCommand : IRequest<ObtenerAgroquimicoDTO>
    {
        public int IdAgroquimico { get; set; }

    }
}
