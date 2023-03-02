using FluentValidation.Results;
using AgroSistema.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public IList<MensajeUsuarioDTO> Errores { get; }
        public ValidationException(MensajeUsuarioDTO message)
            : base(message)
        {
            Errores = new List<MensajeUsuarioDTO>();
        }

        public ValidationException(IList<ValidationFailure> errors, IEnumerable<MensajeUsuarioDTO> messages)
            : this(messages.FirstOrDefault(x => x.Codigo == "000004"))
        {

            var errorCodes = errors
                .Select(e => e.ErrorCode)
                .Distinct();

            foreach (var code in errorCodes)
            {
                Errores.Add(messages.FirstOrDefault(x => x.Codigo == code));
            }
        }


    }
}
