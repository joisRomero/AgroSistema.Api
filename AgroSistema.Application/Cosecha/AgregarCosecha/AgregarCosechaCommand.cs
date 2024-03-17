using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cosecha.AgregarCosecha
{
    public class AgregarCosechaCommand : IRequest
    {
        public DateTime? FechaCosecha { get; set; }
        public int IdCampania { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
        public IEnumerable<CosechaDetalleDTO>? ListaCosechaDetalle { get; set; }
    }
}
