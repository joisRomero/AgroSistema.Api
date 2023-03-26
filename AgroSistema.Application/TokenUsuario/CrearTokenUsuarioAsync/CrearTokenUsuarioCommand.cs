﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TokenUsuario.CrearTokenUsuarioAsync
{
    public class CrearTokenUsuarioCommand : IRequest<CrearTokenUsuarioDTO>
    {
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public Guid? ClientId { get; set; }
    
    }
}
