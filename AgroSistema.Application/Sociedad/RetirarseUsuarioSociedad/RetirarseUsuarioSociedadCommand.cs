using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.RetirarseUsuarioSociedad
{
    public class RetirarseUsuarioSociedadCommand : IRequest
    {
        public int IdUsuario { get; set; }
        public int IdSociedad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
