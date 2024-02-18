﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Usuario.Command.ValidarCodigoRecuperacionCuenta
{
    public class ValidarCodigoRecuperacionCuentaCommand : IRequest
    {
        public string? Correo { get; set; }
        public string? Token { get; set; }
    }
}
