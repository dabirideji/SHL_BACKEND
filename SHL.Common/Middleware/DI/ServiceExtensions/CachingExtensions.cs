public static class CachingExtensions
{
    public static IServiceCollection AddCaching(this IServiceCollection services)
    {
        services.AddMemoryCache();
        // services.AddResponseCaching();
        // services.AddOutputCache();
        return services;
    }
}
