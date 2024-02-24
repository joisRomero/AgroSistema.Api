using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetGastoDetallePorId
{
    public class ObtenerGastoDetalleCommand : IRequest<ObtenerGastoDetalleDTO>
    {
        public int IdGastoDetalle { get; set; }
    }
}
