using SHL.Application.Interfaces;
using SHL.Repository;

public static class DbConnectionAccessorExtension
{
    public static IServiceCollection AddDbConnectionAccessor(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionAccessor, DbConnectionAccessor>();
        services.AddScoped<IDatabaseContextAccessor, DatabaseContextAccessor>();
        return services;
    }
}
