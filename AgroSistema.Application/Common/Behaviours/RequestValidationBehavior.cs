using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Settings;
using ValidationException = AgroSistema.Application.Common.Exceptions.ValidationException;

namespace AgroSistema.Application.Common.Behaviours
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IMemoryCache _memoryCache;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IMemoryCache memoryCache)
        {
            _validators = validators;
            _memoryCache = memoryCache;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures, _memoryCache.Get<IEnumerable<MensajeUsuarioDTO>>(ApplicationConstants.UserMessageMemoryCacheKey));
            }

            return next();
        }
    }
}
