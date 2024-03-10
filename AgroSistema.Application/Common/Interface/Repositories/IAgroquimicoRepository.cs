using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarAgroquimicoAsync;
using AgroSistema.Domain.Entities.EditarAgroquimicoAsync;
using AgroSistema.Domain.Entities.EliminarAgroquimicoAsync;
using AgroSistema.Domain.Entities.GetAgroquimicoPorIdAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaAgroquimicoAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IAgroquimicoRepository
    {
        Task<PaginatedEntity<IEnumerable<AgroquimicoPaginadoEntity>>> GetListaPaginadaAgroquimicoAsync(ListaPaginadaAgroquimicoEntity listaPaginadaAgroquimicoEntity);
        Task AgregarAgroquimico(AgregarAgroquimicoEntity agregarAgroquimicoEntity);
        Task EditarAgroquimico(EditarAgroquimicoEntity editarAgroquimicoEntity);
        Task EliminarAgroquimico(EliminarAgroquimicoEntity eliminarAgroquimicoEntity);
        Task<ObtenerAgroquimicoEntity> GetAgroquimicoPorIdAsync(int idAgroquimico);
    }
}
