using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarDetalleActividadAsync
{
    public class ListarDetalleActividadCommand : IRequest<DetalleActividadDTO>
    {
        public int IdActividad { get; set; }
    }
}
