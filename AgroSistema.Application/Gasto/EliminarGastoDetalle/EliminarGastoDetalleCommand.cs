using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.EliminarGastoDetalle
{
    public class EliminarGastoDetalleCommand : IRequest
    {
        public int IdGastoDetalle { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
