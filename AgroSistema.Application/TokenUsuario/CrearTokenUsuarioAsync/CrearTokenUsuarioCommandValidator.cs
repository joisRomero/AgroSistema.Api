using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.TokenUsuario.CrearTokenUsuarioAsync
{
    public class CrearTokenUsuarioCommandValidator : AbstractValidator<CrearTokenUsuarioCommand>
    {
        public CrearTokenUsuarioCommandValidator()
        {
            RuleFor(p => p.Usuario).Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode("002030");

            RuleFor(p => p.Clave).Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode("002031");

            RuleFor(p => p.ClientId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode("002001");
        }
    }
}
