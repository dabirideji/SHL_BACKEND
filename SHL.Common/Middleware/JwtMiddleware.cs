using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SHL.Application.Interfaces;
using SHL.Application.CustomExceptions;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public JwtMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var appSettingAccessor = scope.ServiceProvider.GetRequiredService<IAppSettingAccessor>();
                AttachUserToContext(context, token, appSettingAccessor);
            }
        }

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, string token, IAppSettingAccessor appSettingAccessor)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var secretKey = appSettingAccessor.GetValue("JWTCredentials", "SecretKey");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            foreach (var claim in claimsPrincipal.Claims)
            {
                context.Items[claim.Type] = claim.Value;
            }
        }
        catch (Exception ex)
        {
            ApiException.ServerError(ex.Message,99,ex);
            Console.WriteLine($"Error attaching user to context: {ex.Message}");
        }
    }
}
