using SHL.Application.Interfaces;
using SHL.Domain.IRepository;
using SHL.Infrastructure.Repository;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbMigration, DbMigration>();
        services.AddScoped<IDbContextRepository, DbContextRepository>();
        services.AddScoped<IDbRepository, DapperDbRepository>();
        return services;
    }
}
