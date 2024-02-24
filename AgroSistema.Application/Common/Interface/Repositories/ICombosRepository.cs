using AgroSistema.Domain.Entities.GetCalidadesCosechaAsync;
using AgroSistema.Domain.Entities.GetCultivosUsuarioaAsync;
using AgroSistema.Domain.Entities.GetTipoActividadXUsuarioAsync;
using AgroSistema.Domain.Entities.GetTipoTrabajadorXUsuarioAsync;
using AgroSistema.Domain.Entities.GetUnidadesCampaniaAsync;
using AgroSistema.Domain.Entities.GetUnidadesCosechaAsync;
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
    }
}
