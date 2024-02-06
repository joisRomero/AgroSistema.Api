using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Cultivo.ListarCultivosAsync;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.ListarSociedad
{
    public class ListarSociedadQuery : IRequest<PaginatedDTO<IEnumerable<ListarSociedadesDTO>>>
    {
        public string? NombreSociedad { get; set; }
        public int? IdUsuario { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
