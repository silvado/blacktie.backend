using Application.Abstractions.Messaging;
using Application.Contracts.Sistema;
using Domain.Interfaces.Behaviors;

namespace Application.Queries.GetSistemaConfig
{
    public sealed record GetSistemaConfigQuery(bool? ignoreCache) : IQuery<SistemaConfigDto?>, ICacheableRequest
    {
        public string CacheKey => $"GetSistemaConfigQuery-{this.GetHashCode()}";
        public bool IgnoreCache => ignoreCache ?? false;
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(30);
    }
}
