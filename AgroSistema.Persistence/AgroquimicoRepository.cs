using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAgroquimicoAsync;
using AgroSistema.Domain.Entities.EditarAgroquimicoAsync;
using AgroSistema.Domain.Entities.EliminarAgroquimicoAsync;
using AgroSistema.Domain.Entities.GetAgroquimicoPorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync;
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
    public class AgroquimicoRepository : IAgroquimicoRepository
    {
        private readonly IDataBase _dataBase;
        public AgroquimicoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task AgregarAgroquimico(AgregarAgroquimicoEntity agregarAgroquimicoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@nombreAgroquimico", agregarAgroquimicoEntity.NombreAgroquimico);
            parameters.Add("@idTipoAgroquimico", agregarAgroquimicoEntity.IdTipoAgroquimico);
            parameters.Add("@descripcion", agregarAgroquimicoEntity.Descripcion);
            parameters.Add("@usuarioInserta", agregarAgroquimicoEntity.UsuarioInserta);
            parameters.Add("@idUsuario", agregarAgroquimicoEntity.IdUsuario);

            await cnn.ExecuteAsync(
                "sp_AgregarAgroquimico",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EditarAgroquimico(EditarAgroquimicoEntity editarAgroquimicoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAgroquimico", editarAgroquimicoEntity.IdAgroquimico);
            parameters.Add("@nombreAgroquimico", editarAgroquimicoEntity.NombreAgroquimico);
            parameters.Add("@idTipoAgroquimico", editarAgroquimicoEntity.IdTipoAgroquimico);
            parameters.Add("@descripcion", editarAgroquimicoEntity.Descripcion);
            parameters.Add("@usuarioModifica", editarAgroquimicoEntity.UsuarioModifica);


            await cnn.ExecuteAsync(
                "sp_EditarAgroquimico",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarAgroquimico(EliminarAgroquimicoEntity eliminarAgroquimicoEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAgroquimico", eliminarAgroquimicoEntity.IdAgroquimico);
            parameters.Add("@usuarioElimina", eliminarAgroquimicoEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_EliminarAgroquimico",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerAgroquimicoEntity> GetAgroquimicoPorIdAsync(int idAgroquimico)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idAgroquimico", idAgroquimico);

            var response = await cnn.QueryAsync<ObtenerAgroquimicoEntity>("sp_ObtenerAgroquimicoPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<PaginatedEntity<IEnumerable<AgroquimicoPaginadoEntity>>> GetListaPaginadaAgroquimicoAsync(ListaPaginadaAgroquimicoEntity listaPaginadaAgroquimicoEntity)
        {
            using var cnn = _dataBase.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pNombre", listaPaginadaAgroquimicoEntity.Nombre);
            parameters.Add("@idTipoAgroquimico", listaPaginadaAgroquimicoEntity.IdTipoAgroquimico);
            parameters.Add("@pIdUsuario", listaPaginadaAgroquimicoEntity.IdUsuario);
            parameters.Add("@pPageNumber", listaPaginadaAgroquimicoEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaAgroquimicoEntity.PageSize);

            var response = await cnn.QueryAsync<AgroquimicoPaginadoEntity>("sp_ObtenerListaPaginadaAgroquimico", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<AgroquimicoPaginadoEntity>>(listaPaginadaAgroquimicoEntity.PageNumber, listaPaginadaAgroquimicoEntity.PageSize, totalRows, response);
        }
    }
}
