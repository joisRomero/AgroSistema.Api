using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Agroquimico.EditarAgroquimico
{
    public class EditarAgroquimicoCommand : IRequest
    {
        public int IdAgroquimico { get; set; }
        public string? NombreAgroquimico { get; set; }
        public int IdTipoAgroquimico { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
