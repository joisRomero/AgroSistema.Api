﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Entities.AgregarCultivoAsync
{
    public class AgregarCultivoEntity
    {
        public string? NombreCultivo { get; set; }
        public int IdUsuario { get; set; }
        public string? UsuarioInserta { get; set; }
    }
}
