using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.EditarCampaniaAsync;
using AgroSistema.Domain.Entities.EliminarCampaniaAsync;
using AgroSistema.Domain.Entities.FinalizarCampaniaAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasUsuarioAsync;
using AgroSistema.Domain.Entities.ObtenerCampaniaEntity;
using AgroSistema.Domain.Entities.RegistrarCampaniaAsync;
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

        public async Task RegistrarCampaniaAsync(RegistrarCampaniaEntity registrarCamapaniaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_nombreTerreno_camp", registrarCamapaniaEntity.NombreTerreno);
            parameters.Add("@p_areaSembrar_camp", registrarCamapaniaEntity.AreaSembrar);
            parameters.Add("@p_unidadTerrenoDatoComun_camp", registrarCamapaniaEntity.UnidadTerreno);
            parameters.Add("@p_nombre_camp", registrarCamapaniaEntity.NombreCampania);
            parameters.Add("@p_descripcion_camp", registrarCamapaniaEntity.DescripcionCampania);
            parameters.Add("@p_fechaInicio_camp", registrarCamapaniaEntity.FechaInicio);
            parameters.Add("@p_id_culti", registrarCamapaniaEntity.IdCultivo);
            parameters.Add("@p_id_soc", registrarCamapaniaEntity.IdSociedad);
            parameters.Add("@p_id_usu", registrarCamapaniaEntity.IdUsuario);
            parameters.Add("@p_usuarioInserta_camp", registrarCamapaniaEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_crear_campania",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task EditarCampaniaAsync(EditarCampaniaEntity editarCampaniaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_camp", editarCampaniaEntity.IdCampania);
            parameters.Add("@p_nombreTerreno_camp", editarCampaniaEntity.NombreTerreno);
            parameters.Add("@p_areaSembrar_camp", editarCampaniaEntity.AreaSembrar);
            parameters.Add("@p_unidadTerrenoDatoComun_camp", editarCampaniaEntity.UnidadTerreno);
            parameters.Add("@p_nombre_camp", editarCampaniaEntity.NombreCampania);
            parameters.Add("@p_descripcion_camp", editarCampaniaEntity.DescripcionCampania);
            parameters.Add("@p_fechaInicio_camp", editarCampaniaEntity.FechaInicio);
            parameters.Add("@p_id_culti", editarCampaniaEntity.IdCultivo);
            parameters.Add("@p_id_soc", editarCampaniaEntity.IdSociedad);
            parameters.Add("@p_id_usu", editarCampaniaEntity.IdUsuario);
            parameters.Add("@p_usuarioModifica_camp", editarCampaniaEntity.UsuarioModifica);

            await cnn.ExecuteAsync(
                "sp_editar_campania",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task EliminarCampaniaAsync(EliminarCampaniaEntity eliminarCampaniaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_camp", eliminarCampaniaEntity.IdCampania);
            parameters.Add("@p_usuarioElimina_camp", eliminarCampaniaEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_eliminar_campania",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task FinalizarCampaniaAsync(FinalizarCampaniaEntity finalizarCampaniaEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_camp", finalizarCampaniaEntity.IdCampania);
            parameters.Add("@p_fechaFin_camp", finalizarCampaniaEntity.FechaFinaliza);
            parameters.Add("@p_usuarioModifica_camp", finalizarCampaniaEntity.UsuarioModifica);

            await cnn.ExecuteAsync(
                "sp_finalizar_campania",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ObtenerCampaniaEntity> ObtenerCampaniaAsync(int idCampania)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@pIdCampania", idCampania);

            var response = await cnn.QueryAsync<ObtenerCampaniaEntity>("sp_ObtenerCampaniaPorId", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            response.First();
            return response.First();
        }
    }
}
