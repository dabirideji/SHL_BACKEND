using SHL.Application.Interfaces.GenericRepositoryPattern;

public static class UnitOfWorkExtensions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
       // services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
