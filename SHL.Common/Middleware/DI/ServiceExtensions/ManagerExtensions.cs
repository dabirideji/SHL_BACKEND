using SHL.Application.IManagers;
using SHL.Infrastructure.Managers;

public static class ManagerExtensions
{
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<ICacheManager, CacheManager>();
        return services;
    }
}
