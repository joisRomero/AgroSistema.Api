using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.EliminarTipoTrabjadorAsync;
using AgroSistema.Domain.Entities.ListaPaginadaTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.ModificarTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.ObtenerTipoTrabajadorAsync;
using AgroSistema.Domain.Entities.RegistrarTipoTrabajadorAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ITipoTrabajador
    {
        Task RegistrarTipoTrabajadorAsync(RegistrarTipoTrabajadorEntity entity);
        Task ModificarTipoTrabajadorAsync(ModificarTipoTrabajadorEntity entity);
        Task EliminarTipoTrabjadorAsync(EliminarTipoTrabajadorEntity eliminarTipoTrabajadorEntity);
        Task<PaginatedEntity<IEnumerable<ListaPaginadaTipoTrabajadorEntity>>> ListarPaginadaTipoTrabajadorAsync(RequestListaPaginadaTipoTrabajadorEntity entity);
        Task<ObtenerTipoTrabajadorEntity> ObtenerTipoTrabajadorAsync(int idTipoTrabajador);
    }
}
