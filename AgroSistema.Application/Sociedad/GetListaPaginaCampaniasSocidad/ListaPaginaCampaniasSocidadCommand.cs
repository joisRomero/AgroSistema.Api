using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.GetListaPaginaCampaniasSocidad
{
    public class ListaPaginaCampaniasSocidadCommand : IRequest<PaginatedDTO<IEnumerable<CampaniasSocidadPaginadaDTO>>>
    {
        public int IdSociedad { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
