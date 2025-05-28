using Microsoft.EntityFrameworkCore;
using SHL.Repository.Data.Context;

public static class DbContextExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<SHLTennantDbContext>(provider =>
        {
            var dbAccessor = provider.GetRequiredService<IDbConnectionAccessor>();
            var httpAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            var dbFactory = provider.GetRequiredService<IDbContextFactory>();

            return new SHLTennantDbContext(dbAccessor, httpAccessor, dbFactory);
        });

        services.AddDbContext<SHLMasterDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MasterConnection"),
                b => b.MigrationsAssembly("SHL.Repository"));
        });
        services.AddDbContext<EstockDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("EstockConnection"),
                b => b.MigrationsAssembly("SHL.Repository"));
        });
        return services;
    }
}
