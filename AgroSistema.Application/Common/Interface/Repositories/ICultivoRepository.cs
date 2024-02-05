using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICultivoRepository
    {
        Task AgregarCultivo(AgregarCultivoEntity agregarCultivoEntity);
        Task<PaginatedEntity<IEnumerable<ListaPaginadaCultivoEntity>>> ListarCultivosAsync(RequestListaPaginadaCultivoEntity requestListaPaginadaCultivoEntity);
    }
}
