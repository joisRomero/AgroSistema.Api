using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Abono.EditarAbono
{
    public class EditarAbonoCommand :IRequest
    {
        public int IdAbono { get; set; }
        public string? NombreAbono { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
