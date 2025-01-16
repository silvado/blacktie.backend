using Domain.Interfaces.Behaviors;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.CodeAnalysis;

namespace Application.Behaviors
{
    [ExcludeFromCodeCoverage]
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheableRequest
    {
        private readonly IMemoryCache _cache;

        public CachingBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            // Gerar a chave de cache da requisição
            var cacheKey = request.CacheKey;

            // Tentar obter a resposta do cache
            if (!request.IgnoreCache && _cache.TryGetValue(cacheKey, out TResponse? cachedResponse))
            {
                return cachedResponse!;
            }

            // Executar o próximo handler na pipeline
            var response = await next();

            // Armazenar a resposta no cache
            _cache.Set(cacheKey, response, request.CacheDuration);

            return response;
        }
    }
}
