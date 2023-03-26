using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Login
{
    public class LoginCommand : IRequest<LoginDTO>
    {
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
    }
}
