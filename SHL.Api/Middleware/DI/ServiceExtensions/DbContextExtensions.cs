using Microsoft.EntityFrameworkCore;
using SHL.Repository.Data.Context;
public static class DbContextExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        // TENNANT CONFIG
        services.AddDbContext<SHLTennantDbContext>();
        //services.AddDbContextFactory<SHLTennantDbContext>(options =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("DEFAULT_SQL_SERVER_CONNECTION"),
        //        b => b.MigrationsAssembly("SHL.Repository"));
        //});

        // services.AddDbContext<SHLTennantDbContext>(options =>
        // options.UseSqlServer(configuration.GetConnectionString("DEFAULT_SQL_SERVER_CONNECTION")));


        // MASTER CONFIG
        services.AddDbContext<SHLMasterDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MasterConnection"),
                b => b.MigrationsAssembly("SHL.Repository"));
                       
        });

        // services.AddDbContext<SHLMasterDbContext>(options =>
        // options.UseSqlServer(configuration.GetConnectionString("AdminConnection")));

        return services;
    }
}