using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.MensajeUsuario.Queries
{
    public class GetMensajesUsuarioQueryValidator : AbstractValidator<GetMensajesUsuarioQuery>
    {
        public GetMensajesUsuarioQueryValidator()
        {
            RuleFor(p => p.AplicacionId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode("000006");
        }
    }
}
