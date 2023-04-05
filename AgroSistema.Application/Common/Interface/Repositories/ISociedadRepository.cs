using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ISociedadRepository
    {
        Task<PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>> GetListaPaginadaSociedadesAsync(ListaPaginadaSociedadEntity listaPaginadaSociedadEntity);
        Task<IEnumerable<IntegrantesSociedadEntity>> ObtenerIntegrantesSociedadAsync(int idSociedad);
        Task<int> ValidarPertenenciaSociedad(int idUsuario, int idSociedad);
        Task<PaginatedEntity<IEnumerable<CampaniasSociedadPaginadaEntity>>> GetListaPaginaCampaniasSocidadAsync(ListaPaginadaCampaniasSociedadEntity listaPaginadaCampaniasSociedadEntity);
    }
}
