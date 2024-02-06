using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.AgregarSociedad
{
    public class AgregarSociedadCommand : IRequest
    {
        public string? NombreSociedad { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
