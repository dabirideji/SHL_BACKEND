
namespace SHL.Application.Interfaces
{
    public interface IDbConnectionAccessor
    {
        string GetConnectionString(string domainName,DatabaseType databaseType = DatabaseType.SQL_SERVER);
       // Task<string> DeployDatabaseInstance(string domainName);
    }
}
