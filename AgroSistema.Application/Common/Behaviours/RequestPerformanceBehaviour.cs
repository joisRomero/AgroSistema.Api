using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AgroSistema.Application.Common.Dtos;
using AgroSistema.Application.Common.Interface.Repositories;
using AgroSistema.Application.Common.Interface;
using AgroSistema.Application.Common.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IMemoryCache _memoryCache;
        private readonly IMensajeUsuarioRepository _mensajeUsuarioRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUser currentUser, IMemoryCache memoryCache, IMensajeUsuarioRepository mensajeUsuarioRepository,
            IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _currentUser = currentUser;
            _memoryCache = memoryCache;
            _mensajeUsuarioRepository = mensajeUsuarioRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            await ObtenerMensajes();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > _appSettings.LongRequestTimeMilliseconds)
            {
                _logger.LogWarning("Request de {0} de larga duración {1} ({2} milliseconds)", _currentUser.Identifier, typeof(TRequest).Name, _timer.ElapsedMilliseconds);
            }

            return response;
        }

        private async Task ObtenerMensajes()
        {
            if (!_memoryCache.TryGetValue(ApplicationConstants.UserMessageMemoryCacheKey, out _))
            {
                var mensajes = await _mensajeUsuarioRepository.GetListaAsync(Guid.Parse(_appSettings.ApplicationId));
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(_appSettings.SlidingExpirationCacheTimeSeconds));
                _memoryCache.Set(ApplicationConstants.UserMessageMemoryCacheKey, _mapper.Map<IEnumerable<MensajeUsuarioDTO>>(mensajes), cacheEntryOptions);
            }
        }
    }
}
