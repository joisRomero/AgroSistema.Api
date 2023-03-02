using AgroSistema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IMensajeUsuarioRepository
    {
        Task<IEnumerable<MensajeUsuarioEntity>> GetListaAsync(Guid aplicacionGuid);
    }
}
