using Hangfire;
using Hangfire.MemoryStorage; 

public static class HangfireServiceExtension
{

    // public static IServiceCollection AddDefaultHangfireConfiguration(this IServiceCollection services)
    // {
    //     services.AddHangfire((serviceProvider, config) =>
    //     {
    //         using (var scope = serviceProvider.CreateScope())
    //         {
    //             var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory>();
    //             var dbContextType = scope.ServiceProvider.GetRequiredService<IDatabaseContextAccessor>().GetDatabaseContextType();

    //             string projectRoot = Directory.GetCurrentDirectory();
    //             string directory = Path.Combine(projectRoot, "wwwroot");

    //             if (!Directory.Exists(directory))
    //             {
    //                 Directory.CreateDirectory(directory);
    //             }

    //             string filePath = Path.Combine(directory, $"{dbContextType}-MAIN.sqlite");

    //             // if (!File.Exists(filePath))
    //             // {
    //             //     File.Create(filePath).Dispose();
    //             // }

    //             string connectionString = $"Data Source={Path.GetFullPath(filePath)};";

    //             Console.WriteLine($"Database File Path: {filePath}");
    //             Console.WriteLine($"File Exists: {File.Exists(filePath)}");

    //             try
    //             {
    //                 config.UseSimpleAssemblyNameTypeSerializer();
    //                 config.UseRecommendedSerializerSettings();
    //                 config.UseSQLiteStorage(connectionString);
    //             }
    //             catch (Exception ex)
    //             {
    //                 Console.WriteLine($"Error configuring Hangfire: {ex.Message}");
    //                 throw;
    //             }
    //         }
    //     });

    //     services.AddHangfireServer();

    //     return services;
    // }

 public static IServiceCollection AddDefaultHangfireConfiguration(this IServiceCollection services)
    {
        services.AddHangfire((serviceProvider, config) =>
        {
            config.UseMemoryStorage();
        });

        services.AddHangfireServer(); // Starts the Hangfire background job server
        return services;
    }
}
