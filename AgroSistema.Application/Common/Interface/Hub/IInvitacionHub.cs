using AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Hub
{
    public interface IInvitacionHub
    {
        Task EnviarNotificacionInvitacion(IEnumerable<ListarInvitacionesSociedadDTO> listaInvitaciones);
    }
}
