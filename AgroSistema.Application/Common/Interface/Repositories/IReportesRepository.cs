using AgroSistema.Domain.Entities.Reportes.ReportesInicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Interface.Repositories
{
    public interface IReportesRepository
    {
        Task<CantidadProcesosCampaniasEntity> ReporteInicioCantidadProcesosCampaniasAsync(int idUsuario);
        Task<IEnumerable<CantidadCultivosCampaniasEntity>> ReporteInicioCantidadCultivosCampaniasAsync(int idUsuario);
        Task<IEnumerable<GastosCultivosCampaniasEntity>> ReporteInicioGastosCultivosCampaniasAsync(int idUsuario);
        Task<IEnumerable<CampaniasTerminadasTopEntity>> ReporteInicioCampaniasTerminadasTopAsync(int idUsuario);
        Task<IEnumerable<UltimasSociedadesUsuarioEntity>> ReporteInicioUltimasSociedadesUsuarioAsync(int idUsuario);
        Task<IEnumerable<CampaniaProcesoUsuarioEntity>> ReporteCampaniasProcesoUsuarioAsync(int idUsuario);
    }
}
