using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.EditarCosecha
{
    public class EditarCosechaCommand : IRequest
    {
        public int IdCosecha { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public int IdCampania { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
        public IEnumerable<CosechaDetalleRequestDTO>? ListaCosechaDetalle { get; set; }
    }
}
