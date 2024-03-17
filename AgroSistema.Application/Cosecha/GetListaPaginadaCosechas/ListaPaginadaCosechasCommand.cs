using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.GetListaPaginadaCosechas
{
    public class ListaPaginadaCosechasCommand : IRequest<PaginatedDTO<IEnumerable<CosechasPaginadaDTO>>>
    {
        public int IdCampania { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
