using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Cultivo.AgregarCultivoAsync
{
    public class AgregarCultivoCommand : IRequest
    {
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? CodUsuario { get; set; }
    }
}
