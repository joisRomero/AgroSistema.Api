using AgroSistema.Domain.Entities.CambiarEstadoInvitacionAsync;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.RegistrarInvitacionSociedadAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IInvitacionRepository
    {
        Task<IEnumerable<ListarInvitacionesSociedadEntity>> ListarInvitacionesSociedadAsync(RequestListarInvitacionesSociedadEntity requestListarInvitacionesSociedadEntity);
        Task RegistrarInvitacionSociedadAsync(RegistrarInvitacionSociedadEntity registrarInvitacionSociedadEntity);
        Task CambiarEstadoInvitacionAsync(CambiarEstadoInvitacionEntity cambiarEstadoInvitacionEntity);
    }
}
