using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.ObtenerCosecha
{
    public class ObtenerCosechaCommand : IRequest<ObtenerCosechaDTO>
    {
        public int IdCosecha{ get; set; }

    }
}
