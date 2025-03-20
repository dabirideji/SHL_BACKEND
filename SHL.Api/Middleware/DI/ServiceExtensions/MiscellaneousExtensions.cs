using Microsoft.Extensions.Diagnostics.HealthChecks;

public static class MiscellaneousExtensions
{
    public static IServiceCollection AddMiscellaneousServices(this IServiceCollection services)
    {
        // services.AddHealthChecks()
        //         .AddSqlServer("your_connection_string", name: "SQL Server") // Example: Check database connection
        //         .AddCheck("self", () => HealthCheckResult.Healthy("The API is healthy")) // Simple custom check
        //         .AddUrlGroup(new Uri("http://example.com"), name: "External API") // Example: Check external API
        //         .AddRedis("localhost", name: "Redis", tags: new[] { "redis", "db" }) // Example: Redis check
        //         .AddRabbitMQ("amqp://localhost", name: "RabbitMQ", tags: new[] { "message-broker" }); // Example: RabbitMQ check

        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy("The API is healthy"));
        return services;
    }
}

