using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.AgregarAgroquimico
{
    public class AgregarAgroquimicoCommand : IRequest
    {
        public string? NombreAgroquimico { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
