using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarNotificacionAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.ListarNotificacionesAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface INotificacionRepository
    {
        Task<IEnumerable<ListarNotificacionesEntity>> ListaNotificacionesAsync(ListarNotificacionesRequestEntity listarNotificacionesRequestEntity);
        Task AgregarNotificacion(AgregarNotificacionEntity agregarNotificacionEntity);
    }
}
