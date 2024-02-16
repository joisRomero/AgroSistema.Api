using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync
{
    public class ListarInvitacionesSociedadQuery : IRequest<IEnumerable<ListarInvitacionesSociedadDTO>>
    {
        public int? IdUsuario { get; set; }
    }
}
