using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IGastoRepository
    {
        Task<PaginatedEntity<IEnumerable<TipoGastoPaginadoEntity>>> GetListaPaginadaTipoGastoAsync(ListaPaginadaTipoGastoEntity listaPaginadaTipoGastoEntity);
        Task AgregarTipoGasto(AgregarTipoGastoEntity agregarTipoGastoEntity);
        Task EditarTipoGasto(EditarTipoGastoEntity editarTipoGastoEntity);
        Task EliminarTipoGasto(EliminarTipoGastoEntity eliminarTipoGastoEntity);
        Task<ObtenerTipoGastoEntity> GetTipoGastoPorIdAsync(int idTipoGasto);
    }
}
