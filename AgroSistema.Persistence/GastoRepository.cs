using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarGastoDetalleAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AgroSistema.Domain.Entities.EditarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EditarSociedadAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using AgroSistema.Domain.Entities.EliminarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EliminarSociedadAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using AgroSistema.Domain.Entities.GetGastoDetallePorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Persistence
{
    public class GastoRepository : IGastoRepository
    {
        private readonly IDataBase _dataBase;

        public GastoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarGastoDetalle(AgregarGastoDetalleEntity agregarGastoDetalleEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCampania", agregarGastoDetalleEntity.IdCampania);
            parameters.Add("@idTipoGasto", agregarGastoDetalleEntity.IdTipoGasto);
            parameters.Add("@fechaGasto", agregarGastoDetalleEntity.FechaGasto);
            parameters.Add("@cantidad", agregarGastoDetalleEntity.Cantidad);
            parameters.Add("@costoUnitario", agregarGastoDetalleEntity.CostoUnitario);
            parameters.Add("@costoTotal", agregarGastoDetalleEntity.CostoTotal);
            parameters.Add("@descripcion", agregarGastoDetalleEntity.Descripcion);
            parameters.Add("@usuarioInserta", agregarGastoDetalleEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_AgregarGastoDetalle",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task AgregarTipoGasto(AgregarTipoGastoEntity agregarTipoGastoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@nombreTipoGasto", agregarTipoGastoEntity.NombreTipoGasto);
            parameters.Add("@descripcion", agregarTipoGastoEntity.Descripcion);
            parameters.Add("@usuarioInserta", agregarTipoGastoEntity.UsuarioInserta);
            parameters.Add("@idUsuario", agregarTipoGastoEntity.IdUsuario);

            await cnn.ExecuteAsync(
                "sp_AgregarTipoGasto",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarGastoDetalle(EditarGastoDetalleEntity editarGastoDetalleEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idGastoDetalle", editarGastoDetalleEntity.IdGastoDetalle);
            parameters.Add("@idTipoGasto", editarGastoDetalleEntity.IdTipoGasto);
            parameters.Add("@fechaGasto", editarGastoDetalleEntity.FechaGasto);
            parameters.Add("@cantidad", editarGastoDetalleEntity.Cantidad);
            parameters.Add("@costoUnitario", editarGastoDetalleEntity.CostoUnitario);
            parameters.Add("@costoTotal", editarGastoDetalleEntity.CostoTotal);
            parameters.Add("@descripcion", editarGastoDetalleEntity.Descripcion);
            parameters.Add("@usuarioModifica", editarGastoDetalleEntity.UsuarioModifica);

            await cnn.ExecuteAsync(
                "sp_EditarGastoDetalle",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarTipoGasto(EditarTipoGastoEntity editarTipoGastoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idTipoGasto", editarTipoGastoEntity.IdTipoGasto);
            parameters.Add("@nombreTipoGasto", editarTipoGastoEntity.NombreTipoGasto);
            parameters.Add("@descripcion", editarTipoGastoEntity.Descripcion);
            parameters.Add("@usuarioModifica", editarTipoGastoEntity.UsuarioModifica);


            await cnn.ExecuteAsync(
                "sp_EditarTipoGasto",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarGastoDetalle(EliminarGastoDetalleEntity eliminarGastoDetalleEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idGastoDetalle", eliminarGastoDetalleEntity.IdGastoDetalle);
            parameters.Add("@usuarioElimina", eliminarGastoDetalleEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarGastoDetalle",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarTipoGasto(EliminarTipoGastoEntity eliminarTipoGastoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idTipoGasto", eliminarTipoGastoEntity.IdTipoGasto);
            parameters.Add("@usuarioElimina", eliminarTipoGastoEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarTipoGasto",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerGastoDetalleEntity> GetGastoDetallePorIdAsync(int idGastoDetalle)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idGastoDetalle", idGastoDetalle);

            var response = await cnn.QueryAsync<ObtenerGastoDetalleEntity>("sp_ObtenerGastoDetallePorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<PaginatedEntity<IEnumerable<GastoDetallePaginadoEntity>>> GetListaPaginadaGastoDetalleAsync(ListaPaginadaGastoDetalleEntity listaPaginadaGastoDetalleEntity)
        {
            using var cnn = _dataBase.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdCampania", listaPaginadaGastoDetalleEntity.IdCampania);
            parameters.Add("@pIdTipoGasto", listaPaginadaGastoDetalleEntity.IdTipoGasto);
            parameters.Add("@pFechaGasto", listaPaginadaGastoDetalleEntity.FechaGasto);
            parameters.Add("@pPageNumber", listaPaginadaGastoDetalleEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaGastoDetalleEntity.PageSize);

            var response = await cnn.QueryAsync<GastoDetallePaginadoEntity>("sp_ObtenerListaPaginadaGastoDetalle", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<GastoDetallePaginadoEntity>>(listaPaginadaGastoDetalleEntity.PageNumber, listaPaginadaGastoDetalleEntity.PageSize, totalRows, response);
        }

        public async Task<PaginatedEntity<IEnumerable<TipoGastoPaginadoEntity>>> GetListaPaginadaTipoGastoAsync(ListaPaginadaTipoGastoEntity listaPaginadaTipoGastoEntity)
        {
            using var cnn = _dataBase.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pNombre", listaPaginadaTipoGastoEntity.Nombre);
            parameters.Add("@pIdUsuario", listaPaginadaTipoGastoEntity.IdUsuario);
            parameters.Add("@pPageNumber", listaPaginadaTipoGastoEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaTipoGastoEntity.PageSize);

            var response = await cnn.QueryAsync<TipoGastoPaginadoEntity>("sp_ObtenerListaPaginadaTipoGasto", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<TipoGastoPaginadoEntity>>(listaPaginadaTipoGastoEntity.PageNumber, listaPaginadaTipoGastoEntity.PageSize, totalRows, response);
        }

        public async Task<ObtenerTipoGastoEntity> GetTipoGastoPorIdAsync(int idTipoGasto)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idTipoGasto", idTipoGasto);

            var response = await cnn.QueryAsync<ObtenerTipoGastoEntity>("sp_ObtenerTipoGastoPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }
    }
}
