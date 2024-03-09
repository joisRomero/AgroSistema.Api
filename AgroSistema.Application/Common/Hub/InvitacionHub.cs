using AgroSistema.Application.Common.Interface.Hub;
using AgroSistema.Application.Invitacion.ListarInvitacionesSociedadAsync;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Hub
{
    public class InvitacionHub : Hub<IInvitacionHub>
    {
        public async Task AgregarAGrupo(string nombreGrupo)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, nombreGrupo);
        }
       
    }
}
