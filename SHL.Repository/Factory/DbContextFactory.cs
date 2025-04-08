using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IRepository;
using SHL.Application.IServices;
using SHL.Domain.Models.Categories;

public class DbContextFactory : IDbContextFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration configuration;

    public DbContextFactory(IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        this.configuration = configuration;
    }

    public DbContext CreateDbContext(string clientId = "", DatabaseType databaseType = DatabaseType.SQL_SERVER)
    {
        if (string.IsNullOrEmpty(clientId))
        {
            var clientIdService = _serviceProvider.GetRequiredService<IClientIdService>();
            clientId = clientIdService.GetClientId();
        }
        var connectionStringAccessor = _serviceProvider.GetRequiredService<IDbConnectionAccessor>();
        var dbContextAccessor = _serviceProvider.GetRequiredService<IDatabaseContextAccessor>();
        var dbContextRepository = _serviceProvider.GetRequiredService<IDbContextRepository>();
        // Retrieve the connection string
        var connectionString = connectionStringAccessor.GetConnectionString(clientId, databaseType);
        // Dynamically create the appropriate DbContext based on the context type
        var contextType = dbContextAccessor.GetDatabaseContextType();
        return contextType switch
        {
            DatabaseContextType.MASTER => dbContextRepository.CreateDbContext<SHLMasterDbContext>(connectionString, databaseType),
            DatabaseContextType.TENNANT => dbContextRepository.CreateDbContext<SHLTennantDbContext>(connectionString, databaseType),
            _ => throw new ArgumentException("Invalid database context type", nameof(contextType))
        };
    }

    //string BuildConnectionString(string domainName)
    //{
    //    if (string.IsNullOrEmpty(domainName)) return "";

    //    domainName = domainName.Replace('.', '_');
    //    var connectionString = string.Format(configuration["ConnectionStringFormat"]!, domainName);
    //    return connectionString;

    //}

    //public string? 
    //    GetConnectionString()
    //{
    //    using (var scope = _serviceProvider.CreateScope())
    //    {
    //        var SHLMasterDbContext = scope.ServiceProvider.GetRequiredService<SHLMasterDbContext>();
    //        var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
    //        var userIdentityService = scope.ServiceProvider.GetRequiredService<IUserIdentityService>();

    //        if (httpContextAccessor.HttpContext is not null && httpContextAccessor.HttpContext!.User!.Identity!.IsAuthenticated)
    //        {
    //            var companyId = userIdentityService.CompanyId;
    //            var connectionString = SHLMasterDbContext.CompanyInfo.Where(c => c.Id == companyId)
    //                .Select(s => s.ConnectionString)
    //                .FirstOrDefault();

    //            return connectionString;
    //        }
    //        else
    //        {
    //            if (httpContextAccessor.HttpContext is not null && httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("x-domain", out var xDomain))
    //            {
    //                var connectionString = SHLMasterDbContext.CompanyInfo.Where(c => c.NormalizedDomainName == xDomain!.FirstOrDefault()!.ToUpperInvariant())
    //                .Select(s => s.ConnectionString)
    //                .FirstOrDefault();

    //                if (string.IsNullOrEmpty(connectionString))
    //                {
    //                    connectionString = BuildConnectionString(xDomain);
    //                }
    //                return connectionString;
    //            }

    //            var defaultSqlServerConnectionString = configuration.GetConnectionString("DefaultConnection");
    //            return defaultSqlServerConnectionString;
    //        }

    //    }

    //}



    //public async Task<string> DeployDatabaseInstance(string domainName)
    //{
    //    using (var scope = _serviceProvider.CreateScope())
    //    {
    //        var SHLMasterDbContext = scope.ServiceProvider.GetRequiredService<SHLMasterDbContext>();
    //        var SHLTenantDbContext = scope.ServiceProvider.GetRequiredService<SHLTennantDbContext>();

    //        //var company = await SHLMasterDbContext.CompanyInfo.FirstOrDefaultAsync(c => c.NormalizedDomainName == domainName.ToUpperInvariant());
    //        //if (company is not null)
    //        //    throw new Exception("company already onboarded");

    //        var connectionstring = BuildConnectionString(domainName);

    //        try
    //        {
    //            // SHLTenantDbContext.Database.SetConnectionString(connectionstring);
    //            if (SHLTenantDbContext.Database.GetPendingMigrations().Any())
    //            {
    //                await SHLTenantDbContext.Database.MigrateAsync();
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine($"EXCEPTION DURING MIGRATION : {e.Message.ToUpper()}");

    //            throw;
    //        }
    //        // await SHLTenantDbContext.Database.MigrateAsync();
    //        var isCreated = await SHLTenantDbContext.Database.EnsureCreatedAsync();
    //        return connectionstring;
    //    }


}
