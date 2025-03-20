using Microsoft.EntityFrameworkCore;
using SHL.Repository.Data.Context;
using System;

namespace SHL.Api.Middleware
{
    public class DatabaseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;

        public DatabaseMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("x-domain", out var databaseName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SHLTennantDbContext>();

                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        await dbContext.Database.MigrateAsync();
                    }                    
                }
            }

            await _next(context);
        }

    }
}
