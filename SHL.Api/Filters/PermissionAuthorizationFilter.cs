using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class PermissionAuthorizeAttributeFilter : Attribute, IAuthorizationFilter
{
    private readonly string[] _requiredPermissions;

    public PermissionAuthorizeAttributeFilter(params string[] requiredPermissions)
    {
        _requiredPermissions = requiredPermissions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var permissions = context.HttpContext.Items["Permissions"] as List<string>;

        if (permissions == null || !_requiredPermissions.Any(p => permissions.Contains(p)))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
