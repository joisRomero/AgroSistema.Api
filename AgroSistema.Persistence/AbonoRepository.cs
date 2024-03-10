using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAbonoAsync;
using AgroSistema.Domain.Entities.AgregarTipoGastoAsync;
using AgroSistema.Domain.Entities.EditarAbonoAsync;
using AgroSistema.Domain.Entities.EditarGastoDetalleAsync;
using AgroSistema.Domain.Entities.EditarTipoGastoAsync;
using AgroSistema.Domain.Entities.EliminarAbonoAsync;
using AgroSistema.Domain.Entities.EliminarTipoGastoAsync;
using AgroSistema.Domain.Entities.GetAbonoPorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaTipoGastoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoPorIdAsync;
using AgroSistema.Domain.Entities.ListaPaginadaAbonoAsync;
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
    public class AbonoRepository : IAbonoRepository
    {
        private readonly IDataBase _dataBase;

        public AbonoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task AgregarAbono(AgregarAbonoEntity agregarAbonoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@nombreAbono", agregarAbonoEntity.NombreAbono);
            parameters.Add("@descripcion", agregarAbonoEntity.Descripcion);
            parameters.Add("@usuarioInserta", agregarAbonoEntity.UsuarioInserta);
            parameters.Add("@idUsuario", agregarAbonoEntity.IdUsuario);

            await cnn.ExecuteAsync(
                "sp_AgregarAbono",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarAbono(EditarAbonoEntity editarAbonoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAbono", editarAbonoEntity.IdAbono);
            parameters.Add("@nombreAbono", editarAbonoEntity.NombreAbono);
            parameters.Add("@descripcion", editarAbonoEntity.Descripcion);
            parameters.Add("@usuarioModifica", editarAbonoEntity.UsuarioModifica);


            await cnn.ExecuteAsync(
                "sp_EditarAbono",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarAbono(EliminarAbonoEntity eliminarAbonoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAbono", eliminarAbonoEntity.IdAbono);
            parameters.Add("@usuarioElimina", eliminarAbonoEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarAbono",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerAbonoEntity> GetAbonoPorIdAsync(int idAbono)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAbono", idAbono);

            var response = await cnn.QueryAsync<ObtenerAbonoEntity>("sp_ObtenerAbonoPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<PaginatedEntity<IEnumerable<AbonoPaginadoEntity>>> GetListaPaginadaAbonoAsync(ListaPaginadaAbonoEntity listaPaginadaAbonoEntity)
        {
            using var cnn = _dataBase.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pNombre", listaPaginadaAbonoEntity.Nombre);
            parameters.Add("@pIdUsuario", listaPaginadaAbonoEntity.IdUsuario);
            parameters.Add("@pPageNumber", listaPaginadaAbonoEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaAbonoEntity.PageSize);

            var response = await cnn.QueryAsync<AbonoPaginadoEntity>("sp_ObtenerListaPaginadaAbono", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<AbonoPaginadoEntity>>(listaPaginadaAbonoEntity.PageNumber, listaPaginadaAbonoEntity.PageSize, totalRows, response);
        }
    }
}
