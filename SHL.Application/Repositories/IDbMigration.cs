using SHL.Domain.Models.Categories;

namespace SHL.Application.IRepository
{
    public interface IDbMigration
    {
        /// <summary>
        /// MIGRATES ALL DATABASES ASYNCHRONOUSLY
        /// </summary>
        /// <param name="databaseConfigs">A LIST OF DATABASE CONFIGURATIONS WITH CONTEXT TYPE AND CONNECTION STRING</param>
        /// <returns>A TASK THAT REPRESENTS THE ASYNCHRONOUS OPERATION</returns>
        Task MigrateAllDatabasesAsync(List<(Type contextType, string connectionString)> databaseConfigs);

        /// <summary>
        /// MIGRATES A SINGLE DATABASE ASYNCHRONOUSLY
        /// </summary>
        /// <typeparam name="T">THE DB CONTEXT TYPE TO MIGRATE</typeparam>
        /// <param name="connectionString">THE CONNECTION STRING FOR THE DATABASE</param>
        /// <returns>A TASK THAT REPRESENTS THE ASYNCHRONOUS OPERATION</returns>
        Task MigrateDatabaseAsync<T>(string connectionString, DatabaseType databaseType = DatabaseType.SQL_SERVER) where T : Microsoft.EntityFrameworkCore.DbContext;
        /// <summary>
        /// MIGRATES A SINGLE DATABASE ASYNCHRONOUSLY - FLEX DB CLIENT
        /// </summary>
        /// <param name="connectionString">THE CONNECTION STRING FOR THE DATABASE</param>
        /// <param name="databaseType">THE DATABASE TYPE FOR THE DATABASE</param>
        /// <returns>A TASK THAT REPRESENTS THE ASYNCHRONOUS OPERATION</returns>
        Task MigrateDatabaseAsync(string connectionString, DatabaseType databaseType = DatabaseType.SQL_SERVER);
    }
}