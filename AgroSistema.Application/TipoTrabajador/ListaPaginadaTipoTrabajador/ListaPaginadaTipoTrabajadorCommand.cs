using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TipoTrabajador.ListaPaginadaTipoTrabajador
{
    public class ListaPaginadaTipoTrabajadorCommand : IRequest<PaginatedDTO<IEnumerable<TipoTrabajadorPaginadoDTO>>>
    {
        public string? NombreTipoTrabajador { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
