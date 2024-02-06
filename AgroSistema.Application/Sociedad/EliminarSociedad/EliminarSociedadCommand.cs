using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.EliminarSociedad
{
    public class EliminarSociedadCommand : IRequest
    {
        public int IdSociedad { get; set; }
        public string? UsuarioElimina { get; set; }

    }
}
