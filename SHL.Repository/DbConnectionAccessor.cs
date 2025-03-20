using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Domain.Models.Categories;
using System.Threading.Tasks;

namespace SHL.Repository
{
    public class DbConnectionAccessor : IDbConnectionAccessor
    {
        private readonly IAppSettingAccessor _appSettingAccessor;
        private readonly IFileService _fileService;
        private readonly IDbContextFactory dbContextFactory;

        public DbConnectionAccessor(IAppSettingAccessor appSettingAccessor, IFileService fileService,
            IDbContextFactory dbContextFactory)
        {
            _appSettingAccessor = appSettingAccessor;
            _fileService = fileService;
            this.dbContextFactory = dbContextFactory;

        }

        public string GetConnectionString(string clientId, DatabaseType databaseType = DatabaseType.SQL_SERVER)
        {
            var connStr = dbContextFactory.GetConnectionString();

            if (!string.IsNullOrEmpty(connStr))
                return connStr;

            var contextDatabaseType = databaseType.ToString().ToUpper();
            var subKey = $"DEFAULT_{contextDatabaseType}_CONNECTION";
            var targetConnectionString = _appSettingAccessor.GetValue("ConnectionStrings", subKey);

            if (string.IsNullOrEmpty(targetConnectionString))
            {
                throw new InvalidOperationException($"Connection string for {subKey} not found in configuration.");
            }
            return targetConnectionString;

            // var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "Data", clientId);
            var basePath = Path.Combine("Data", clientId);
            _fileService.CreateDirectory(basePath); // Ensure directory exists

            var dbName = clientId;
            return targetConnectionString
                .Replace("[CLIENT_ID]", clientId)
                .Replace("[DB_NAME]", dbName);
        }

        
    }
}
