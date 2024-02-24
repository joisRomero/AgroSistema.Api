using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetTipoGasto
{
    public class ObtenerTipoGastoCommand : IRequest<ObtenerTipoGastoDTO>
    {
        public int IdTipoGasto { get; set; }
    }
}
