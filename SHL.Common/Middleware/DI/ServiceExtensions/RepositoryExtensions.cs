using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Repository.Factory;
using SHL.Repository.Repositories;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbMigration, DbMigration>();
        services.AddScoped<IDbContextRepository, DbContextRepository>();
        services.AddScoped<IDbRepository, DapperDbRepository>();
        services.AddScoped<IUnitOfWork, SHL.Repository.Repositories.UnitOfWork>();
        services.AddScoped<IDapper,DapperServices>();
        // Registering all repository interfaces with their implementations
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IShareholderRepository, ShareholderRepository>();
        services.AddScoped<IUserVerificationRepository, UserVerificationRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ILgaRepository, LgaRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        return services;
    }
}
