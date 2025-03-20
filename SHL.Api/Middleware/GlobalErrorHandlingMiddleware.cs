using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SHL.Application.CustomExceptions;
using SHL.Application.Response;
using System.Net;
using System.Text.Json;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

    public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unhandled exception occurred: {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }


    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {

            ApiException => (int)HttpStatusCode.BadRequest,
            ValidationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };


        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = statusCode == (int)HttpStatusCode.BadRequest ? "Client Error" : "Server Error",
            Detail = exception.Message,
            Instance = context.Request.Path
        };
        var isApiException = exception is ApiException;
        if (exception is ApiException apiException)
        {
            problemDetails.Extensions["errorCode"] = apiException.ErrorCode;
            problemDetails.Extensions["additionalData"] = apiException.AdditionalData;
        }

        var response = new DefaultResponse<ProblemDetails>();
        response.Status = false;
        response.ResponseCode = (!isApiException) ? "04" : (problemDetails.Extensions["errorCode"].ToString() ?? problemDetails.Status.ToString());
        response.ResponseMessage = problemDetails.Detail;
        response.Data = problemDetails;
        // response.Data = null;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }

}
