using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarActividadTrabajadorGastosAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
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

            await cnn.ExecuteAsync(
                "sp_agregar_actividad_trabajador_gastos",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
