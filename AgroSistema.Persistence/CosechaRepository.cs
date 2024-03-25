using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCosechaAsync;
using AgroSistema.Domain.Entities.EditarCosechaAsync;
using AgroSistema.Domain.Entities.EliminarCosechaAsync;
using AgroSistema.Domain.Entities.GetCosechaPorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using AgroSistema.Domain.Entities.ListarCosechaDetalleAsync;
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
    public class CosechaRepository : ICosechaRepository
    {
        private readonly IDataBase _database;
        public CosechaRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarCosecha(AgregarCosechaEntity agregarCosechaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@fechaCosecha", agregarCosechaEntity.FechaCosecha);
            parameters.Add("@idCampania", agregarCosechaEntity.IdCampania);
            parameters.Add("@descripcion", agregarCosechaEntity.Descripcion);
            parameters.Add("@usuarioInserta", agregarCosechaEntity.UsuarioInserta);
            parameters.Add("@xmlCosechaDetalle", agregarCosechaEntity.XML_ListaCosechaDetalle);

            await cnn.ExecuteAsync(
                "sp_AgregarCosecha",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarCosecha(EditarCosechaEntity editarCosechaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCosecha", editarCosechaEntity.IdCosecha);
            parameters.Add("@fechaCosecha", editarCosechaEntity.FechaCosecha);
            parameters.Add("@idCampania", editarCosechaEntity.IdCampania);
            parameters.Add("@descripcion", editarCosechaEntity.Descripcion);
            parameters.Add("@usuarioModifica", editarCosechaEntity.UsuarioModifica);
            parameters.Add("@xmlCosechaDetalle", editarCosechaEntity.ListaCosechaDetalle);

            await cnn.ExecuteAsync(
                "sp_EditarCosecha",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarCosecha(EliminarCosechaEntity eliminarCosechaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCosecha", eliminarCosechaEntity.IdCosecha);
            parameters.Add("@usuarioElimina", eliminarCosechaEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarCosecha",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarCosechaDetalle(int idCosechaDetalle, string usuarioElimina)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCosechaDetalle", idCosechaDetalle);
            parameters.Add("@usuarioElimina", usuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarCosechaDetalle",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DetalleCosechaDetalleEntity>> GetCosechaDetallePorIdAsync(int idCosecha)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCosecha", idCosecha);

            var response = await cnn.QueryAsync<DetalleCosechaDetalleEntity>("sp_ObtenerCosechaDetallePorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<ObtenerCosechaEntity> GetCosechaPorIdAsync(int idCosecha)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idCosecha", idCosecha);

            var response = await cnn.QueryAsync<ObtenerCosechaEntity>("sp_ObtenerCosechaPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>> GetListaPaginadaCosechasAsync(ListaPaginadaCosechasEntity listaPaginadaCosechasEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdCampania", listaPaginadaCosechasEntity.IdCampania);
            parameters.Add("@pPageNumber", listaPaginadaCosechasEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaCosechasEntity.PageSize);
            parameters.Add("@pFechaCosecha", listaPaginadaCosechasEntity.FechaCosecha);


            var response = await cnn.QueryAsync<CosechaPaginadaEntity>("sp_ObtenerListaPaginadaCosechas", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>(listaPaginadaCosechasEntity.PageNumber, listaPaginadaCosechasEntity.PageSize, totalRows, response);
        }
    }
}
