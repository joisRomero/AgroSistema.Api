using AgroSistema.Application.Combos.GetUnidadFumigacion;
using AgroSistema.Application.Common.Interface.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Reportes.ReporteInicioAsync
{
    public class ReporteInicioCommandHandler : IRequestHandler<ReporteInicioCommand, ReporteInicioDTO>
    {
        private readonly IReportesRepository _reportesRepository;
        private readonly IMapper _mapper;
        public ReporteInicioCommandHandler(IReportesRepository reportesRepository, IMapper mapper)
        {
            _reportesRepository = reportesRepository;
            _mapper = mapper;
        }

        public async Task<ReporteInicioDTO> Handle(ReporteInicioCommand request, CancellationToken cancellationToken)
        {
            var reporteInicioCantidadProcesosCampanias = await _reportesRepository.ReporteInicioCantidadProcesosCampaniasAsync(request.IdUsuario);
            var reporteInicioCantidadCultivosCampanias = await _reportesRepository.ReporteInicioCantidadCultivosCampaniasAsync(request.IdUsuario);
            var reporteInicioGastosCultivosCampanias = await _reportesRepository.ReporteInicioGastosCultivosCampaniasAsync(request.IdUsuario);
            var reporteInicioCampaniasTerminadasTop = await _reportesRepository.ReporteInicioCampaniasTerminadasTopAsync(request.IdUsuario);
            var reporteInicioUltimasSociedadesUsuario = await _reportesRepository.ReporteInicioUltimasSociedadesUsuarioAsync(request.IdUsuario);
            var reporteCampaniasProcesoUsuario = await _reportesRepository.ReporteCampaniasProcesoUsuarioAsync(request.IdUsuario);

            IEnumerable<CultivosCampaniaDTO> cultivosCampaniaDTOs = reporteInicioCantidadCultivosCampanias.Select(
                                    item => new CultivosCampaniaDTO 
                                    { 
                                        Cultivo = item.NombreCultivo, 
                                        Cantidad = item.TotalCultivosCampania 
                                    });

            IEnumerable<GastosCultivosDTO> gastosCultivosDTOs = reporteInicioGastosCultivosCampanias.Select(
                 item => new GastosCultivosDTO
                 {
                     Cultivo = item.NombreCultivo,
                     Gasto =  item.TotalGasto
                 });
            IEnumerable<CampaniasTerminadasTopDTO> campaniasTerminadasTopDTOs = reporteInicioCampaniasTerminadasTop.Select(
                item => new CampaniasTerminadasTopDTO
                {
                    Campania = item.NombreCampania,
                    Gasto = item.TotalGasto
                });

            IEnumerable<UltimasSociedadesUsuarioDTO> ultimasSociedadesUsuarioDTOs = reporteInicioUltimasSociedadesUsuario.Select(
                item => new UltimasSociedadesUsuarioDTO
                {
                    NombreSociedad = item.NombreSociedad
                });

            IEnumerable<CampaniaProcesoUsuarioDTO> campaniaProcesoUsuarioDTOs = reporteCampaniasProcesoUsuario.Select(
                item => new CampaniaProcesoUsuarioDTO
                {
                    Campania = item.NombreCampania,
                    Gasto = item.TotalGasto
                });


            ReporteInicioDTO reporteInicioDTO = new ReporteInicioDTO()
            {
                CampaniasProceso = reporteInicioCantidadProcesosCampanias.P,
                CampaniasTerminadas = reporteInicioCantidadProcesosCampanias.T,
                CampaniasReabiertas = reporteInicioCantidadProcesosCampanias.R,
                CultivosCampania = cultivosCampaniaDTOs,
                GastosCultivos = gastosCultivosDTOs,
                CampaniasTerminadasTop5 = campaniasTerminadasTopDTOs,
                ultimasSociedades = ultimasSociedadesUsuarioDTOs,
                CampaniasProcesoUsuario = campaniaProcesoUsuarioDTOs
            };


            return reporteInicioDTO;
        }
    }
}
