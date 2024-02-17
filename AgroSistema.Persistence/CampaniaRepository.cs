using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
using AgroSistema.Domain.Entities.ValidarCampaniaAsync;
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
    public class CampaniaRepository : ICampaniaRepository
    {
        private readonly IDataBase _database;
        public CampaniaRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<PaginatedEntity<IEnumerable<CampaniasUsuarioPaginadaEntity>>> GetListaPaginaCampaniasUsuarioAsync(ListaPaginadaCampaniasUsuarioEntity listaPaginadaCampaniasSociedadEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pPageNumber", listaPaginadaCampaniasSociedadEntity.PageNumber);
            parameters.Add("@pPageSize", listaPaginadaCampaniasSociedadEntity.PageSize);
            parameters.Add("@pIdUsuario", listaPaginadaCampaniasSociedadEntity.IdUsuario);
            parameters.Add("@pNombre", listaPaginadaCampaniasSociedadEntity.Nombre);

            var response = await cnn.QueryAsync<CampaniasUsuarioPaginadaEntity>("sp_ObtenerListaPaginaCampaniasUsuario", 
                                                                                    parameters, 
                                                                                    commandTimeout: 0, 
                                                                                    commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<CampaniasUsuarioPaginadaEntity>>(listaPaginadaCampaniasSociedadEntity.PageNumber, 
                                                                                    listaPaginadaCampaniasSociedadEntity.PageSize, 
                                                                                    totalRows, 
                                                                                    response);
        }

        public async Task<int> ValidarCampania(ValidarCampaniaEntity validarCampaniaEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdUsuario", validarCampaniaEntity.IdUsuario);
            parameters.Add("@pIdCampania", validarCampaniaEntity.IdCampania);

            int result = 0;
            var response = await cnn.QueryAsync<int>("sp_ValidarPertenenciaCampania", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            result = response.First();
            return result;
        }
    }
}
