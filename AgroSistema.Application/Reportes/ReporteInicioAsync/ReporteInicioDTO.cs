using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Reportes.ReporteInicioAsync
{
    public class ReporteInicioDTO
    {
        public int CampaniasProceso { get; set; }
        public int CampaniasTerminadas { get; set; }
        public int CampaniasReabiertas { get; set; }
        public IEnumerable<CultivosCampaniaDTO>? CultivosCampania { get; set; }
        public IEnumerable<GastosCultivosDTO>? GastosCultivos { get; set; }
        public IEnumerable<CampaniasTerminadasTopDTO>? CampaniasTerminadasTop5 { get; set; }
        public IEnumerable<UltimasSociedadesUsuarioDTO>? ultimasSociedades { get; set; }
        public IEnumerable<CampaniaProcesoUsuarioDTO> CampaniasProcesoUsuario {  get; set; }
    }
}
