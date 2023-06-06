using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCosechasAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ICosechaRepository
    {
        Task<PaginatedEntity<IEnumerable<CosechaPaginadaEntity>>> GetListaPaginadaCosechasAsync(ListaPaginadaCosechasEntity listaPaginadaCosechasEntity);
    }
}
