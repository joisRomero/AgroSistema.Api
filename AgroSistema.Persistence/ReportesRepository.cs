using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.Reportes.ReportesInicio;
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
    public class ReportesRepository : IReportesRepository
    {
        private readonly IDataBase _dataBase;

        public ReportesRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<CantidadProcesosCampaniasEntity> ReporteInicioCantidadProcesosCampaniasAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<CantidadProcesosCampaniasEntity>("sp_reporte_inicio_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response.First();
        }

        public async Task<IEnumerable<CantidadCultivosCampaniasEntity>> ReporteInicioCantidadCultivosCampaniasAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<CantidadCultivosCampaniasEntity>("sp_reporteInicio_cultivosCampania_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<GastosCultivosCampaniasEntity>> ReporteInicioGastosCultivosCampaniasAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<GastosCultivosCampaniasEntity>("sp_reporteInicio_gastosCultivos_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<CampaniasTerminadasTopEntity>> ReporteInicioCampaniasTerminadasTopAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<CampaniasTerminadasTopEntity>("sp_reporteInicio_campaniaTerminada_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<UltimasSociedadesUsuarioEntity>> ReporteInicioUltimasSociedadesUsuarioAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<UltimasSociedadesUsuarioEntity>("sp_reporteInicio_sociedadesTop_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<CampaniaProcesoUsuarioEntity>> ReporteCampaniasProcesoUsuarioAsync(int idUsuario)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_usu", idUsuario);

            var response = await cnn.QueryAsync<CampaniaProcesoUsuarioEntity>("sp_reporteInicio_campaniasProceso_x_usuario", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return response;
        }


        //public async Task ReporteInicioAsync(int idUsuario)
        //{
        //    using var cnn = _dataBase.GetConnection();

        //    DynamicParameters parameters = new();
        //    parameters.Add("@p_id_usu", idUsuario);

        //    var response = await cnn.QueryAsync <>("sp_ObtenerAbonoPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);

        //    return response.First();
        //}
    }
}
