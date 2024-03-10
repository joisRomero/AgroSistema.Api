using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.AgregarAbono
{
    public class AgregarAbonoCommand : IRequest
    {
        public string? NombreAbono { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
