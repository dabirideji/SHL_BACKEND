using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using SHL.Application.Response;

public class ModelStateValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ModelStateValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        var endpoint = context.GetEndpoint();

        if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is not null)
        {
            var actionContext = context.Items["ActionContext"] as ActionContext;

            if (actionContext?.ModelState != null && !actionContext.ModelState.IsValid)
            {
                var res = new DefaultResponse<ValidationProblemDetails>
                {
                    Status = false,
                    ResponseMessage = "ONE OR MORE FIELDS ARE REQUIRED",
                    ResponseCode = "99",
                    Data = new ValidationProblemDetails(actionContext.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Validation Failed",
                        Detail = "One or more validation errors occurred. Please correct them and try again."
                    }
                };

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(res);

                return;
            }
        }
        await _next(context);
    }
}
