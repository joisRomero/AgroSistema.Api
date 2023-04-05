using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ObtenerIntegrantesSociedad
{
    public class ObtenerIntegrantesSociedadCommand : IRequest<IEnumerable<IntegrantesSociedadDTO>>
    {
        public int IdUsuario { get; set; }
        public int IdSociedad { get; set; }
    }
}
