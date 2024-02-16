using AgroSistema.Application.Sociedad.EditarSociedad;
using AgroSistema.Domain.Common;
using AgroSistema.Domain.Entities.AgregarCultivoAsync;
using AgroSistema.Domain.Entities.AgregarSociedadAsync;
using AgroSistema.Domain.Entities.EditarSociedadAsync;
using AgroSistema.Domain.Entities.EliminarSociedadAsync;
using AgroSistema.Domain.Entities.GetListaBusquedaIntegranteAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCampaniasSociedadAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaCultivosAsync;
using AgroSistema.Domain.Entities.GetListaPaginadaSociedades;
using AgroSistema.Domain.Entities.ListaPaginadaSociedadAsync;
using AgroSistema.Domain.Entities.ObtenerIntegrantesSociedadAsync;
using AgroSistema.Domain.Entities.ValidarPertenenciaSociedadAsync;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface ISociedadRepository
    {
        Task<PaginatedEntity<IEnumerable<SociedadPaginadaEntity>>> GetListaPaginadaSociedadesAsync(ListaPaginadaSociedadEntity listaPaginadaSociedadEntity);
        Task<PaginatedEntity<IEnumerable<IntegrantesSociedadEntity>>> ObtenerIntegrantesSociedadAsync(ListaPaginadaIntegrantesSociedadEntity listaPaginadaIntegrantesSociedad);
        Task<ValidarPertenenciaSociedadEntity> ValidarPertenenciaSociedad(int idUsuario, int idSociedad);
        Task EliminarSociedad(EliminarSociedadEntity eliminarSociedadEntity);
        Task AgregarSociedad(AgregarSociedadEntity agregarSociedadEntity);
        Task EditarSociedad(EditarSociedadEntity editarSociedadEntity);
        Task<PaginatedEntity<IEnumerable<ListaPaginadaSociedadesEntity>>> ListarSociedades(RequestListaPaginadaSociedadesEntity requestListaPaginadaSociedadesEntity);
        Task<PaginatedEntity<IEnumerable<CampaniasSociedadPaginadaEntity>>> GetListaPaginaCampaniasSocidadAsync(ListaPaginadaCampaniasSociedadEntity listaPaginadaCampaniasSociedadEntity);
        Task<IEnumerable<ListaBusquedaIntegranteEntity>> ListaBusquedaIntegranteAsync(BusquedaIntegranteEntity busquedaIntegranteEntity);
    }
}
