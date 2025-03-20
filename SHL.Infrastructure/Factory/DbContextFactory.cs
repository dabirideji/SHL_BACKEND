using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces;
using SHL.Application.IRepository;
using SHL.Domain.Models.Categories;

public class DbContextFactory : IDbContextFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public DbContext CreateDbContext(DatabaseContextType contextType, string clientId = "", DatabaseType databaseType = DatabaseType.SQL_SERVER)
    {
        if (string.IsNullOrEmpty(clientId))
        {
            var clientIdService = _serviceProvider.GetRequiredService<IClientIdService>();
            clientId = clientIdService.GetClientId();
        }
        var connectionStringAccessor = _serviceProvider.GetRequiredService<IDbConnectionAccessor>();
        var dbContextRepository = _serviceProvider.GetRequiredService<IDbContextRepository>();
        // Retrieve the connection string
        var connectionString = connectionStringAccessor.GetConnectionString(clientId, databaseType);
        // Dynamically create the appropriate DbContext based on the context type
        return contextType switch
        {
            DatabaseContextType.MASTER => dbContextRepository.CreateDbContext<SHLMasterDbContext>(connectionString, databaseType),
            DatabaseContextType.TENNANT => dbContextRepository.CreateDbContext<SHLTennantDbContext>(connectionString, databaseType),
            _ => throw new ArgumentException("Invalid database context type", nameof(contextType))
        };
    }
}
