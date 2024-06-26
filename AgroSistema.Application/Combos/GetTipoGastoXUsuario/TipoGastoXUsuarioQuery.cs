﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Combos.GetTipoGastoXUsuario
{
    public class TipoGastoXUsuarioQuery : IRequest<IEnumerable<TipoGastoXUsuarioDTO>>
    {
        public int IdUsuario { get; set; }
    }
}
