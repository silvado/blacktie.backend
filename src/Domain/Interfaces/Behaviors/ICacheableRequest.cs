namespace Domain.Interfaces.Behaviors
{
    public interface ICacheableRequest
    {
        string CacheKey { get; }
        bool IgnoreCache { get; }
        TimeSpan CacheDuration { get; }
    }
}
