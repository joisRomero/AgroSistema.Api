using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Gasto.GetListaPaginadaTipoGasto
{
    public class ListaPaginadaTipoGastoCommand : IRequest<PaginatedDTO<IEnumerable<TipoGastoPaginadoDTO>>>
    {
        public string? Nombre { get; set; }
        public int IdUsuario { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
