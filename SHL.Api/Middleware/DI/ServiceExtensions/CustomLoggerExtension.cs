namespace SHL.Api.Middleware.DI.ServiceExtensions
{
    public static class CustomLoggerExtension
    {
        public static IServiceCollection RegisterLogging(this IServiceCollection services)
        {
            // services.AddTransient<TenantLoggingMiddleware>();
            return services;
        }
    }
}