using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Sociedad.EditarSociedad
{
    public class EditarSociedadCommand : IRequest
    {
        public int IdSociedad { get; set; }
        public string? NombreSociedad { get; set; }
        public string? UsuarioModifica { get; set; }
    }
}
