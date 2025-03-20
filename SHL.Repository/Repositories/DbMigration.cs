using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SHL.Application.Interfaces;
using SHL.Application.IRepository;
using SHL.Domain.Models.Categories;
using SHL.Repository.Data.Context;

namespace SHL.Repository.Repository
{
    public class DbMigration : IDbMigration
    {
        private readonly IDbConnectionAccessor _dbConnectionAccessor;
        private readonly IServiceProvider _serviceProvider;
        
        public DbMigration(IDbConnectionAccessor dbConnectionAccessor, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _dbConnectionAccessor = dbConnectionAccessor;
        }

        public async Task MigrateAllDatabasesAsync(List<(Type contextType, string connectionString)> databaseConfigs)
        {
            foreach (var (contextType, connectionString) in databaseConfigs)
            {
                try
                {
                    var method = typeof(DapperDbRepository).GetMethod(nameof(MigrateDatabaseAsync));
                    var genericMethod = method.MakeGenericMethod(contextType);
                    Console.WriteLine($"Database migrated started for context {contextType.Name}: {connectionString}");
                    await (Task)genericMethod.Invoke(this, new object[] { connectionString });
                    Console.WriteLine($"Database migrated completed successfully for context {contextType.Name}: {connectionString}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error migrating database for context {contextType.Name} with connection string {connectionString}: {ex.Message}");
                }
            }
        }

        public async Task MigrateDatabaseAsync(string connectionString,DatabaseType databaseType=DatabaseType.SQL_SERVER) => MigrateDatabaseAsync<SHLTennantDbContext>(connectionString,databaseType);

        public async Task MigrateDatabaseAsync<T>(string connectionString,DatabaseType databaseType=DatabaseType.SQL_SERVER) where T : DbContext
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

                DbContextOptions<T> options=default;
                if(databaseType is DatabaseType.SQL_SERVER){
                    
                    options = new DbContextOptionsBuilder<T>()
                    .UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("SHL.Repository");
                    })
                    .UseLoggerFactory(loggerFactory)
                    .Options;
                }

                if(databaseType is DatabaseType.SQLITE){
                    
                    options = new DbContextOptionsBuilder<T>()
                    .UseSqlite(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("SHL.Repository");
                    })
                    .UseLoggerFactory(loggerFactory)
                    .Options;
                }

                var dbContext = (T)Activator.CreateInstance(typeof(T), options);
                try
                {
                    var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                    if (pendingMigrations.Any())
                    {
                        Console.WriteLine($"Applying migrations to {connectionString}...");
                        await dbContext.Database.MigrateAsync();
                        Console.WriteLine($"Migrations applied to {connectionString}.");
                    }
                    else
                    {
                        Console.WriteLine($"No migrations pending for {connectionString}.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error migrating database {connectionString}: {ex.Message}");
                    throw;
                }
            }
        }

    }
}