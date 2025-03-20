using Serilog;
using Serilog.Events;

namespace SHL.Api.Middleware.DI.ServiceExtensions
{
    public static class LoggingServiceHostExtensions
    {
        public static IHostBuilder AddCustomLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, config) =>
            {
                config
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(
                        "Logs/SHL-{Date}.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Information
                    )
                    .WriteTo.File(
                        "Logs/SHL-Errors-{Date}.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Error
                    )
                    .WriteTo.File(
                        "Logs/Tenants/{Tenant}-SHL-{Date}.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Information,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Tenant} {Message:lj}{NewLine}{Exception}"
                    );
            });

            return hostBuilder;
        }
    }
}