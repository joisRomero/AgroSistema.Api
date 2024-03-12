using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAbonacionEntity;
using AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync;
using AgroSistema.Domain.Entities.AgregarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.AgregarGastoActividadAsync;
using AgroSistema.Domain.Entities.AgregarTrabajadorActividadAsync;
using AgroSistema.Domain.Entities.EliminarActividadAsync;
using AgroSistema.Domain.Entities.ListaPaginadoActividadesAsync;
using AgroSistema.Domain.Entities.ListarDetalleActividadAsync;
using AgroSistema.Domain.Entities.ModificarAbonacionAsync;
using AgroSistema.Domain.Entities.ModificarActividadAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionAsync;
using AgroSistema.Domain.Entities.ModificarFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.ModificarGastosAsync;
using AgroSistema.Domain.Entities.ModificarTrabajadorAsync;
using AgroSistema.Persistence.DataBase;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AgroSistema.Persistence
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly IDataBase _database;
        public ActividadRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarActividadTrabajadorGastosAsync(AgregarActividadTrabajadorGastosEntity agregarActividadTrabajadorGastosEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_fecha_acti", agregarActividadTrabajadorGastosEntity.FechaActividad);
            parameters.Add("@p_descripcion_acti", agregarActividadTrabajadorGastosEntity.DescripcionActividad);
            parameters.Add("@p_cantidadSemilla_acti", agregarActividadTrabajadorGastosEntity.CantidadSemillaActividad);
            parameters.Add("@p_unidadSemillaDatoComun_acti", agregarActividadTrabajadorGastosEntity.UnidadSemilla);
            parameters.Add("@p_id_camp", agregarActividadTrabajadorGastosEntity.IdCampania);
            parameters.Add("@p_id_tipoActi", agregarActividadTrabajadorGastosEntity.IdTipoActividad);
            parameters.Add("@p_usuarioInserta_acti", agregarActividadTrabajadorGastosEntity.UsuarioInserta);
            parameters.Add("@p_XML_Trabajadores", agregarActividadTrabajadorGastosEntity.XML_ListaTrabajadores);
            parameters.Add("@p_XML_Gastos", agregarActividadTrabajadorGastosEntity.XML_ListaGastos);
            parameters.Add("@p_XML_Abonacion", agregarActividadTrabajadorGastosEntity.XML_Abonacion);
            parameters.Add("@p_cantidad_fumi", agregarActividadTrabajadorGastosEntity.CantidadFumigacion);
            parameters.Add("@p_unidadDatoComun_fumi", agregarActividadTrabajadorGastosEntity.UnidadFumigacion);
            parameters.Add("@p_XML_Fumigacion_Detalle", agregarActividadTrabajadorGastosEntity.XML_FumigacionDetalle);

            await cnn.ExecuteAsync(
                "sp_agregar_actividad_trabajador_gastos",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task AgregarGastoActividadAsync(AgregarGastoActividadEntity agregarGastoActividadEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_descripcion_gastoDet", agregarGastoActividadEntity.DescripcionGasto);
                parameters.Add("@p_cantidad_gastoDet", agregarGastoActividadEntity.CantidadGasto);
                parameters.Add("@p_costoUnitario_gastoDet", agregarGastoActividadEntity.CostoUnitario);
                parameters.Add("@p_costoTotal_gastoDet", agregarGastoActividadEntity.CostoTotal);
                parameters.Add("@p_fecha_gastoDet", agregarGastoActividadEntity.FechaGasto);
                parameters.Add("@p_id_tipoGasto", agregarGastoActividadEntity.IdTipoGasto);
                parameters.Add("@p_id_acti", agregarGastoActividadEntity.IdActividad);
                parameters.Add("@p_usuarioInserta_gastoDet", agregarGastoActividadEntity.UsuarioInserta);

                await cnn.ExecuteAsync(
                    "sp_agregar_gastosActividad",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task AgregarTrabajadorAsync(AgregarTrabajadorActividadEntity agregarTrabajadorActividadEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_descripcion_trab", agregarTrabajadorActividadEntity.DescripcionTrabajador);
                parameters.Add("@p_cantidad_trab", agregarTrabajadorActividadEntity.CantidadTrabajador);
                parameters.Add("@p_costoUnitario_trab", agregarTrabajadorActividadEntity.CostoUnitario);
                parameters.Add("@p_costoTotal_trab", agregarTrabajadorActividadEntity.CostoTotal);
                parameters.Add("@p_id_acti", agregarTrabajadorActividadEntity.IdActividad);
                parameters.Add("@p_id_tipoTrab", agregarTrabajadorActividadEntity.IdTipoTrabajador);
                parameters.Add("@p_usuarioInserta_trab", agregarTrabajadorActividadEntity.UsuarioInserta);

                await cnn.ExecuteAsync(
                    "sp_agregar_trabajadorActividad",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task ModificarActividadAsync(ModificarActividadEntity modificarActividadEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_acti", modificarActividadEntity.IdActividad);
                parameters.Add("@p_fecha_acti", modificarActividadEntity.FechaActividad);
                parameters.Add("@p_descripcion_acti", modificarActividadEntity.DescripcionActividad);
                parameters.Add("@p_cantidadSemilla_acti", modificarActividadEntity.CantidadSemillaActividad);
                parameters.Add("@p_unidadSemillaDatoComun_acti", modificarActividadEntity.UnidadSemilla);
                parameters.Add("@p_id_camp", modificarActividadEntity.IdCampania);
                parameters.Add("@p_id_tipoActi", modificarActividadEntity.IdTipoActividad);
                parameters.Add("@p_usuarioModifica_acti", modificarActividadEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_actividad",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task ModificarGastoActividadAsync(ModificarGastosEntity modificarGastosEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_gastoDet", modificarGastosEntity.IdGasto);
                parameters.Add("@p_descripcion_gastoDet", modificarGastosEntity.DescripcionGasto);
                parameters.Add("@p_cantidad_gastoDet", modificarGastosEntity.CantidadGasto);
                parameters.Add("@p_costoUnitario_gastoDet", modificarGastosEntity.CostoUnitario);
                parameters.Add("@p_costoTotal_gastoDet", modificarGastosEntity.CostoTotal);
                parameters.Add("@p_fecha_gastoDet", modificarGastosEntity.FechaGasto);
                parameters.Add("@p_id_tipoGasto", modificarGastosEntity.IdTipoGasto);
                parameters.Add("@p_usuarioModifica_gastoDet", modificarGastosEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_gastosActividad",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ModificarTrabajadorAsync(ModificarTrabajadorEntity modificarTrabajadorEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_trab", modificarTrabajadorEntity.IdTrabajador);
                parameters.Add("@p_descripcion_trab", modificarTrabajadorEntity.DescripcionTrabajador);
                parameters.Add("@p_cantidad_trab", modificarTrabajadorEntity.CantidadTrabajador);
                parameters.Add("@p_costoUnitario_trab", modificarTrabajadorEntity.CostoUnitario);
                parameters.Add("@p_costoTotal_trab", modificarTrabajadorEntity.CostoTotal);
                parameters.Add("@p_id_tipoTrab", modificarTrabajadorEntity.IdTipoTrabajador);
                parameters.Add("@p_usuarioModifica_trab", modificarTrabajadorEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_trabajadorActividad",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PaginatedEntity<IEnumerable<ListaPaginadoActividadesEntity>>> ListaPaginadoActividadesAsync(RequestListaPaginadoActividadesEntity entity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_camp", entity.IdCampania);
            parameters.Add("@p_fecha_acti", entity.FechaActividad);
            parameters.Add("@p_nombre_tipoActi", entity.NombreTipoActividad);
            parameters.Add("@pageSize", entity.PageSize);
            parameters.Add("@pageNumber", entity.PageNumber);

            var response = await cnn.QueryAsync<ListaPaginadoActividadesEntity>("sp_listar_actividades_paginado",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                    commandType: CommandType.StoredProcedure);
            int totalRows = response.Any() ? response.First().TotalRows : 0;
            return new PaginatedEntity<IEnumerable<ListaPaginadoActividadesEntity>>(entity.PageNumber,
                                                                                    entity.PageSize,
                                                                                    totalRows,
                                                                                    response);
        }

        public async Task<ListarDetalleActividadEntity> ObtenerDetalleActividadAsync(int? idActividad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_acti", idActividad);

            var response = await cnn.QueryAsync<ListarDetalleActividadEntity>("sp_obtener_actividad",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                  commandType: CommandType.StoredProcedure);
            var result = response.First();

            return result;
        }

        public async Task<IEnumerable<TrabajadorActividadEntity>> ObtenerTrabajadoresActividadAsync(int? idActividad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_acti", idActividad);

            var response = await cnn.QueryAsync<TrabajadorActividadEntity>("sp_obtener_trabajador_actividad",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                  commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<GastoActividadEntity>> ObtenerGatosActividadAsync(int? idActividad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_acti", idActividad);

            var response = await cnn.QueryAsync<GastoActividadEntity>("sp_obtener_gastos_actividad",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                  commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task EliminarActividadAsync(EliminarActividadEntity eliminarActividadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_acti", eliminarActividadEntity.IdActividad);
            parameters.Add("@p_usuarioElimina_acti", eliminarActividadEntity.UsuarioElimina);

            await cnn.ExecuteAsync(
                "sp_eliminar_actividad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AbonacionActividadEntity>> ObtenerAbonacionActividadAsyn(int? idActividad)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_acti", idActividad);

            var response = await cnn.QueryAsync<AbonacionActividadEntity>("sp_obtener_abonacion_actividad",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                  commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<FumigacionDetalleActividadEntity>> ObtenerFumigacionDetalleActividadAsync(int? idFumigacion)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@p_id_fumi", idFumigacion);

            var response = await cnn.QueryAsync<FumigacionDetalleActividadEntity>("sp_obtener_fumigacion_actividad",
                                                                                    parameters,
                                                                                    commandTimeout: 0,
                                                                                  commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task AgregarAbonacionAsync(AgregarAbonacionEntity agregarAbonacionEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_cantidad_abonaci", agregarAbonacionEntity.CantidadAbonacion);
                parameters.Add("@p_unidadDatoComun", agregarAbonacionEntity.UnidadAbonacion);
                parameters.Add("@p_id_abono", agregarAbonacionEntity.IdAbono);
                parameters.Add("@p_id_acti", agregarAbonacionEntity.IdActividad);
                parameters.Add("@p_usuarioInserta_abonaci", agregarAbonacionEntity.UsuarioInserta);

                await cnn.ExecuteAsync(
                    "sp_agregar_abonacion",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ModificarAbonacionAsync(ModificarAbonacionEntity modificarAbonacionEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_abonaci", modificarAbonacionEntity.IdAbonacion);
                parameters.Add("@p_cantidad_abonaci", modificarAbonacionEntity.CantidadAbonacion);
                parameters.Add("@p_unidadDatoComun", modificarAbonacionEntity.UnidadAbonacion);
                parameters.Add("@p_id_abono", modificarAbonacionEntity.IdAbono);
                parameters.Add("@p_usuarioModifica_abonaci", modificarAbonacionEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_abonacion",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ModificarFumigacionAsync(ModificarFumigacionEntity modificarFumigacionEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_acti", modificarFumigacionEntity.IdActividad);
                parameters.Add("@p_cantidad_fumi", modificarFumigacionEntity.CantidadFumigacion);
                parameters.Add("@p_unidadDatoComun_fumi", modificarFumigacionEntity.UnidadFumigacion);
                parameters.Add("@p_usuarioModifica_fumi", modificarFumigacionEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_fumigacion",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AgregarFumigacionDetalleAsync(AgregarFumigacionDetalleEntity agregarFumigacionDetalleEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_fum", agregarFumigacionDetalleEntity.IdFumigacion);
                parameters.Add("@p_cantidad_fumiDet", agregarFumigacionDetalleEntity.CantidadFumigacionDetalle);
                parameters.Add("@p_unidadDatoComun_fumiDet", agregarFumigacionDetalleEntity.UnidadFumigacionDetalle);
                parameters.Add("@p_usuarioInserta_fumiDet", agregarFumigacionDetalleEntity.UsuarioInserta);

                await cnn.ExecuteAsync(
                    "sp_agregar_fumigacion_detalle",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ModificarFumigacionDetalleAsync(ModificarFumigacionDetalleEntity modificarFumigacionDetalleEntity)
        {
            try
            {
                using var cnn = _database.GetConnection();

                DynamicParameters parameters = new();
                parameters.Add("@p_id_fumiDet", modificarFumigacionDetalleEntity.IdFumigacionDetalle);
                parameters.Add("@p_cantidad_fumiDet", modificarFumigacionDetalleEntity.CantidadFumigacionDetalle);
                parameters.Add("@p_unidadDatoComun_fumiDet", modificarFumigacionDetalleEntity.UnidadFumigacionDetalle);
                parameters.Add("@p_usuarioModifica_fumiDet", modificarFumigacionDetalleEntity.UsuarioModifica);

                await cnn.ExecuteAsync(
                    "sp_modificar_fumigacion_detalle",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
