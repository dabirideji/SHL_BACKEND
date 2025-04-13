using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Repository.Repositories;
using SHL.Repository.Repositories.GenericRepositoryImplementations;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbMigration, DbMigration>();
        services.AddScoped<IDbContextRepository, DbContextRepository>();
        services.AddScoped<IDbRepository, DapperDbRepository>();
        services.AddScoped<IUnitOfWork, SHL.Repository.Repositories.UnitOfWork>();

        // Registering all repository interfaces with their implementations
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
