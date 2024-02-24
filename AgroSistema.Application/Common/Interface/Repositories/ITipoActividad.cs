using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.EliminarTipoActividadAsync;
using AgroSistema.Domain.Entities.ListaPaginadaTipoActividadAsync;
using AgroSistema.Domain.Entities.ModificarTipoActividadAsync;
using AgroSistema.Domain.Entities.ObtenerTipoActividadAsync;
using AgroSistema.Domain.Entities.RegistrarTipoActividadAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ITipoActividad
    {
        Task RegistrarTipoActividadAsync(RegistrarTipoActividadEntity registrarTipoActividadEntity);
        Task ModificarTipoActividadAsync(ModificarTipoActividadEntity modificarTipoActividadEntity);
        Task EliminarTipoActividadAsync(EliminarTipoActividadEntity eliminarTipoActividadEntity);
        Task<PaginatedEntity<IEnumerable<ListaPaginadaTipoActividadEntity>>> ListaPaginadaTipoActividadAsync(RequestListaPaginadaTipoActividadEntity entity);
        Task<ObtenerTipoActividadEntity> ObtenerTipoActividadAsync(int idTipoActividad);
        
    }
}
