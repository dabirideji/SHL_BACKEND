using Microsoft.EntityFrameworkCore;

namespace SHL.Application.Interfaces
{
    public interface IDbContextFactory
    {
        //string? GetConnectionString();
       DbContext CreateDbContext(string clientId = "", DatabaseType databaseType = DatabaseType.SQL_SERVER);
        //Task<string> DeployDatabaseInstance(string domainName);
    }
}