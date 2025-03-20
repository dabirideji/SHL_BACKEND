using Microsoft.AspNetCore.OData;
using SHL.Api.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseCors("AllowAll");
       
        app.UseMiddleware<SuccessResponseMiddleware>();
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
        app.UseMiddleware<ModelStateValidationMiddleware>();
        app.UseMiddleware<JwtMiddleware>();
        app.UseMiddleware<DatabaseMiddleware>();
        app.UseCustomLogger();
        app.UseSwagger();
        

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SHL.API V1");
            //c.RoutePrefix = string.Empty;
        });

        app.UseMiddleware<CustomAuthenticationMiddleware>();
        
        app.UseStaticFiles();
        app.UseODataRouteDebug();
        app.UseODataBatching();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.ActivateHangfire();

        return app;
    }
}
