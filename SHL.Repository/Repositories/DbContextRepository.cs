using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SHL.Application.IRepository;
using SHL.Domain.Models.Categories;

namespace SHL.Repository.Repository
{
    public class DbContextRepository : IDbContextRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T CreateDbContext<T>(string connectionString, DatabaseType databaseType) where T : DbContext
        {
            using var scope = _serviceProvider.CreateScope();
            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var dbMigrationService = scope.ServiceProvider.GetRequiredService<IDbMigration>();

            // Create DbContextOptions based on the database type
            var optionsBuilder = new DbContextOptionsBuilder<T>()
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .UseLoggerFactory(loggerFactory);

            switch (databaseType)
            {
                case DatabaseType.SQL_SERVER:
                    optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("SHL.Api");
                    });
                    break;

                case DatabaseType.SQLITE:
                    optionsBuilder.UseSqlite(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("SHL.Api");
                    });
                    break;

                case DatabaseType.POSTGRESQL:
                    optionsBuilder.UseNpgsql(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("SHL.Api");
                    });
                    break;

                default:
                    throw new NotSupportedException($"Unsupported database type: {databaseType}");
            }

            // Perform database migration asynchronously
            Task.Run(async()=>await dbMigrationService.MigrateDatabaseAsync<T>(connectionString, databaseType)).GetAwaiter().GetResult();
            // return DbContext instance
            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
        }
    }
}
