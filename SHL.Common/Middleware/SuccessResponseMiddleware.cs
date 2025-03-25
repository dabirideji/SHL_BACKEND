using System.Text.Json;
using SHL.Application.Response;

public class SuccessResponseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<SuccessResponseMiddleware> _logger;

    public SuccessResponseMiddleware(RequestDelegate next, ILogger<SuccessResponseMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        var originalBodyStream = context.Response.Body;

        using (var memoryStream = new MemoryStream())
        {
            context.Response.Body = memoryStream;

            try
            {
                await _next(context);

                if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var responseBody = new StreamReader(memoryStream).ReadToEnd();

                    if (IsValidJson(responseBody))
                    {
                        var responseObject = JsonSerializer.Deserialize<object>(responseBody);

                        var defaultResponse = new DefaultResponse<object>
                        {
                            Status = true,
                            ResponseCode = context.Response.StatusCode.ToString(),
                            ResponseMessage = "Request was successful.",
                            Data = responseObject
                        };

                        context.Response.Body = originalBodyStream;

                        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                        var jsonResponse = JsonSerializer.Serialize(defaultResponse, options);

                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(jsonResponse);
                    }
                    else
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(originalBodyStream);
                    }
                }
                else
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SuccessResponseMiddleware.");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    Status = false,
                    ResponseCode = "500",
                    ResponseMessage = "Internal Server Error",
                    Data = (object)null
                }));
            }
        }
    }

    private bool IsValidJson(string responseBody)
    {
        return responseBody.StartsWith("{") || responseBody.StartsWith("[");
    }
}
