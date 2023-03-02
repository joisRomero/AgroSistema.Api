using MediatR;
using AgroSistema.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.MensajeUsuario.Queries
{
    public class GetMensajesUsuarioQuery : IRequest<IEnumerable<MensajeUsuarioDTO>>
    {
        public Guid AplicacionId { get; set; }
    }
}
