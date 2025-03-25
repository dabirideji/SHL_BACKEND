using Newtonsoft.Json;
using SHL.Application.Response;

public class DefaultResponseMiddleware
{
    private readonly RequestDelegate _next;

    public DefaultResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;
        await _next(context);
        memoryStream.Seek(0, SeekOrigin.Begin);

        var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

        context.Response.Body = originalBodyStream;

        if (!context.Response.ContentType?.Contains("application/json") ?? true)
        {
            await context.Response.WriteAsync(responseBody);
            return;
        }

        if (context.Response.StatusCode >= 400)
        {
            await context.Response.WriteAsync(responseBody);
            return;
        }

        var response = new DefaultResponse<object>
        {
            Status = true,
            ResponseCode = context.Response.StatusCode.ToString(),
            ResponseMessage = "Request Successful",
            Data = !string.IsNullOrEmpty(responseBody) ? JsonConvert.DeserializeObject<object>(responseBody) : null
        };

        var jsonResponse = JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
    }
}
