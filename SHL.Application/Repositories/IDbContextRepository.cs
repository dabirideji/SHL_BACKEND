using Microsoft.EntityFrameworkCore;
using SHL.Domain.Models.Categories;

namespace SHL.Application.IRepository
{
    public interface IDbContextRepository
    {
        T CreateDbContext<T>(string connectionString, DatabaseType databaseType) where T : DbContext;
    }
}