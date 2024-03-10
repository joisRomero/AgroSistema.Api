using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.EliminarAgroquimico
{
    public class EliminarAgroquimicoCommand : IRequest
    {
        public int IdAgroquimico { get; set; }
        public string? UsuarioElimina { get; set; }
    }
}
