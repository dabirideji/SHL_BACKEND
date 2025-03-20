using System.Net;
using SHL.Application.CustomExceptions;
public class CustomAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public CustomAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var response = new
            {
                message = "Unauthorized access. Please provide a valid token."
            };
            await context.Response.WriteAsJsonAsync(response);
        }

        if(context.Response.StatusCode==(int)HttpStatusCode.Unauthorized)
        {
            ApiException.ClientError("UNAUTHORIZED USER || INVALID ACCESS");
        }
    }
}

