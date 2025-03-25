using Microsoft.AspNetCore.Identity;

namespace SHL.Api.Middleware.DI.ServiceExtensions
{
    public static class IdentityBuilderExtensions
    {
        public static IdentityBuilder AddTotpTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(TotpTokenProvider);
            return builder.AddTokenProvider("TotpTokenProvider", totpProvider);
        }
    }
}
