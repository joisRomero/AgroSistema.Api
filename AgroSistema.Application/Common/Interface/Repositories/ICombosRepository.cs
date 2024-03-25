using AgroSistema.Domain.Entities.GetAbonoUsuarioAsync;
using AgroSistema.Domain.Entities.GetAgroquimicoUsuarioAsync;
using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
using AgroSistema.Domain.Entities.GetCultivosUsuarioaAsync;
using AgroSistema.Domain.Entities.GetTipoActividadXUsuarioAsync;
using AgroSistema.Domain.Entities.GetTipoAgroquimicoAsync;
using AgroSistema.Domain.Entities.GetTipoGastoXUsuarioAsync;
using AgroSistema.Domain.Entities.GetTipoTrabajadorXUsuarioAsync;
using AgroSistema.Domain.Entities.GetUnidadAbonacionAsync;
using AgroSistema.Domain.Entities.GetUnidadesCampaniaAsync;
using AgroSistema.Domain.Entities.GetUnidadesCosechaAsync;
using AgroSistema.Domain.Entities.GetUnidadFumigacionAsync;
using AgroSistema.Domain.Entities.GetUnidadFumigacionDetalleAsync;
using AgroSistema.Domain.Entities.GetUnidadSemillaAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICombosRepository
    {
        Task<IEnumerable<UnidadesCosechaEntity>> GetUnidadesCosechaAsync();
        Task<IEnumerable<CalidadesCosechaEntity>> GetCalidadesCosechaAsync();
        Task<IEnumerable<CultivosUsuarioEntity>> GetCultivosUsuarioAsync(int idUsuario);
        Task<IEnumerable<UnidadesCampaniaEntity>> GetUnidadesCampaniaAsync();
        Task<IEnumerable<TipoTrabajadorXUsuarioEntity>> GetTipoTrabajadorXUsuarioAsync(int idUsuario);
        Task<IEnumerable<TipoActividadXUsuarioEntity>> GetTipoActividadXUsuarioAsync(int idUsuario);
        Task<IEnumerable<TipoGastoXUsuarioEntity>> GetTipoGastoXUsuarioAsync(int idUsuario);
        Task<IEnumerable<GetTipoAgroquimicoEntity>> GetTipoAgroquimicoAsync();
        Task<IEnumerable<UnidadAbonacionEntity>> GetUnidadAbonacionAsync();
        Task<IEnumerable<UnidadFumigacionEntity>> GetUnidadFumigacionAsync();
        Task<IEnumerable<UnidadFumigacionDetalleEntity>> GetUnidadFumigacionDetalleAsync();
        Task<IEnumerable<UnidadSemillaEntity>> GetUnidadSemillaAsync();
        Task<IEnumerable<AbonoUsuarioEntity>> GetAbonoUsuarioAsync(int idUsuario);
        Task<IEnumerable<AgroquimicoUsuarioEntity>> GetAgroquimicoUsuarioAsync(int idUsuario);

    }
}
