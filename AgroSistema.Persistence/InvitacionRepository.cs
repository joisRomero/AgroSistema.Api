using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.CambiarEstadoInvitacionAsync;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AgroSistema.Domain.Entities.GetListaInvitacionesSociedadAsync;
using AgroSistema.Domain.Entities.RegistrarInvitacionSociedadAsync;
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
    public class InvitacionRepository : IInvitacionRepository
    {
        private readonly IDataBase _database;
        public InvitacionRepository(IServiceProvider serviceprovider)
        {
            var services = serviceprovider.GetServices<IDataBase>();
            _database = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ListarInvitacionesSociedadEntity>> ListarInvitacionesSociedadAsync(RequestListarInvitacionesSociedadEntity requestListarInvitacionesSociedadEntity)
        {
            using var cnn = _database.GetConnection();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario", requestListarInvitacionesSociedadEntity.IdUsuario);

            var result = await cnn.QueryAsync<ListarInvitacionesSociedadEntity>("sp_ListarInvitacionesSociedad", parameters,
                                                 commandTimeout: 0, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task RegistrarInvitacionSociedadAsync(RegistrarInvitacionSociedadEntity registrarInvitacionSociedadEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_idEmisor_usu", registrarInvitacionSociedadEntity.IdEmisor);
            parameters.Add("@p_idReceptor_usu", registrarInvitacionSociedadEntity.IdReceptor);
            parameters.Add("@p_id_inviSoc", registrarInvitacionSociedadEntity.IdSociedad);
            parameters.Add("@p_usuarioInserta_inviSoc", registrarInvitacionSociedadEntity.UsuarioInserta);

            await cnn.ExecuteAsync(
                "sp_registrar_invitacion_sociedad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task CambiarEstadoInvitacionAsync(CambiarEstadoInvitacionEntity cambiarEstadoInvitacionEntity)
        {
            using var cnn = _database.GetConnection();

            DynamicParameters parameters = new();
            parameters.Add("@p_id_inviSoc", cambiarEstadoInvitacionEntity.IdInvitacion);
            parameters.Add("@p_accion", cambiarEstadoInvitacionEntity.Accion);
            parameters.Add("@p_usuarioModifica_inviSoc", cambiarEstadoInvitacionEntity.UsuarioModifica);
            

            await cnn.ExecuteAsync(
                "sp_cambiar_estado_invitacion_sociedad",
                param: parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
