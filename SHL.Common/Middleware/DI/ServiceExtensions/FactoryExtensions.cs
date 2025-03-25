using SHL.Application.Interfaces;

public static class FactoryExtensions
{
    public static IServiceCollection RegisterFactories(this IServiceCollection services)
    {
        services.AddScoped<IDbContextFactory, DbContextFactory>();

        //  services.AddSingleton<IDbContextFactory>(provider =>
        // new DbContextFactory(provider, provider.GetRequiredService<IDbConnectionAccessor>()));

        return services;
    }
}
