using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Invitacion.RegistrarInvitacionSociedadAsync
{
    public class RegistrarInvitacionSociedadCommand : IRequest
    {
        public int IdEmisor { get; set; }
        public int IdReceptor { get; set; }
        public int IdSociedad { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
