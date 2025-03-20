using Serilog.Context;

namespace SHL.Api.Middleware
{

    public class TenantLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Extract tenant from a header or query string
            var tenantId = context.Request.Headers["X-Tenant-ID"].FirstOrDefault() ?? "UNKNOWN_TENNANT";

            using (LogContext.PushProperty("TENNANT-ID", tenantId))
            {
                await _next(context);
            }
        }
    }
}