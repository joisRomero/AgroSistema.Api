using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Reportes.ReporteInicioAsync
{
    public class ReporteInicioCommand : IRequest<ReporteInicioDTO>
    {
        public int IdUsuario { get; set; }
    }
}
