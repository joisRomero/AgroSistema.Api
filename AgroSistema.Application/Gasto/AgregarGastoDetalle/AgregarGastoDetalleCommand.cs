using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.AgregarGastoDetalle
{
    public class AgregarGastoDetalleCommand : IRequest
    {
        public int IdCampania { get; set; }
        public int IdTipoGasto { get; set; } 
        public DateTime FechaGasto { get; set; }
        public int Cantidad { get; set; }
        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }

    }
}
