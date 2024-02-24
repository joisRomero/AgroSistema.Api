using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaGastoDetalle
{
    public class ListaPaginadaGastoDetalleCommand : IRequest<PaginatedDTO<IEnumerable<GastoDetallePaginadoDTO>>>
    {
        public int IdCampania { get; set; }
        public int? IdTipoGasto { get; set; }
        public DateTime? FechaGasto { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
