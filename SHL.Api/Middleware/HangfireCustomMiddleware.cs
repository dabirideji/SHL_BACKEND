using Hangfire;

public static class HangfireCustomMiddleware
{
    public static IApplicationBuilder ActivateHangfire(this IApplicationBuilder app)
    {
        // Use Hangfire Dashboard for monitoring jobs
        app.UseHangfireDashboard("/hangfire");

        return app;
    }
}

