using AgroSistema.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Actividad.ListarActividadesPaginadoAsync
{
    public class ListarActividadesPaginadoCommand : IRequest<PaginatedDTO<IEnumerable<ActividadesPaginadoDTO>>>
    {
        public int? IdCampania { get; set; }
        public DateTime? FechaActividad { get; set; }
        public string? NombreTipoActividad { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
