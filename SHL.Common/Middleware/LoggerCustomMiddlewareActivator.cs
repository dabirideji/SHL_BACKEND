using SHL.Api.Middleware;

public static class LoggerCustomMiddlewareActivator
{
    public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder app)
    {
        app.UseMiddleware<TenantLoggingMiddleware>();
        app.UseHealthChecks("/health");
        return app;
    }
}