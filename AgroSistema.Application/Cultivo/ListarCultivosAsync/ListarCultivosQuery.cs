using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.ListarCultivosAsync
{
    public class ListarCultivosQuery: IRequest<PaginatedDTO<IEnumerable<ListarCultivosDTO>>>
    {
        public string? NombreCultivo { get; set; }
        public int? IdUsuario { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
