using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarGastoDetalleAsync;
using AgroSistema.Domain.Entities.AgregarNotificacionAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaGastoDetalleAsync;
using AgroSistema.Domain.Entities.ListarNotificacionesAsync;
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
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly IDataBase _dataBase;

        public NotificacionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task AgregarNotificacion(AgregarNotificacionEntity agregarNotificacionEntity)
        {
            using var cnn = _dataBase.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@idUsuario", agregarNotificacionEntity.IdUsuario);
            parameters.Add("@descripcion", agregarNotificacionEntity.Descripcion);

            await cnn.ExecuteAsync(
                "sp_AgregarNotificacion",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ListarNotificacionesEntity>> ListaNotificacionesAsync(ListarNotificacionesRequestEntity listarNotificacionesRequestEntity)
        {
            using var cnn = _dataBase.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario", listarNotificacionesRequestEntity.IdUsuario);
            parameters.Add("@idCaso", listarNotificacionesRequestEntity.IdCaso);

            var response = await cnn.QueryAsync<ListarNotificacionesEntity>("sp_ListarNotificaciones", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
