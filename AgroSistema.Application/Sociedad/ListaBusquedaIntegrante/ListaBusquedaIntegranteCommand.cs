using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListaBusquedaIntegrante
{
    public class ListaBusquedaIntegranteCommand : IRequest<IEnumerable<BusquedaIntegranteDTO>>
    {
        public string? Nombre { get; set; }
        public int IdUsuario { get; set; }
    }
}
