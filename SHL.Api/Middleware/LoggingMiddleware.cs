using System.Diagnostics;

namespace SHL.Api.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            var stopwatch = Stopwatch.StartNew();

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                _logger.LogInformation(
                    $"Outgoing Response: {context.Response.StatusCode}, " +
                    $"Elapsed: {stopwatch.ElapsedMilliseconds}ms, " +
                    $"Response Body: {responseText}");

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }
}