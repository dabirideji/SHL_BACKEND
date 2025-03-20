using Microsoft.EntityFrameworkCore;

namespace SHL.Domain.IRepository
{
    public interface IDbContextRepository
    {
        T CreateDbContext<T>(string connectionString, DatabaseType databaseType) where T : DbContext;
    }
}