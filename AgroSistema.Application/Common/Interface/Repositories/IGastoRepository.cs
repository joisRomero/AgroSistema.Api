using AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarGastoDetalleAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AgroSistema.Domain.Entities.EditarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using AgroSistema.Domain.Entities.EliminarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using AgroSistema.Domain.Entities.GetGastoDetallePorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync;
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


        Task<PaginatedEntity<IEnumerable<GastoDetallePaginadoEntity>>> GetListaPaginadaGastoDetalleAsync(ListaPaginadaGastoDetalleEntity listaPaginadaGastoDetalleEntity);
        Task AgregarGastoDetalle(AgregarGastoDetalleEntity agregarGastoDetalleEntity);
        Task EditarGastoDetalle(EditarGastoDetalleEntity editarGastoDetalleEntity);
        Task EliminarGastoDetalle(EliminarGastoDetalleEntity eliminarGastoDetalleEntity);
        Task<ObtenerGastoDetalleEntity> GetGastoDetallePorIdAsync(int idGastoDetalle);
    }
}
