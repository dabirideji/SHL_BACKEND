using Microsoft.AspNetCore.Identity;
using SHL.Application.Services;
using SHL.Application.TokenProviders;
using SHL.Application.TwoAuthenticatorProviders;

namespace SHL.Application
{
    public static class CustomIdentityBuilderExtensions
    {
        public static IdentityBuilder AddTotpTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(TotpTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider(AppTokenProvider.TotpProvider, totpProvider);
        }

        public static IdentityBuilder AddSmsMfaTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(SmsTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider(AppTokenProvider.TwoFASmsProvider, totpProvider);
        }

        public static IdentityBuilder AddEmailMfaTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(EmailTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider(AppTokenProvider.TwoFAEmailProvider, totpProvider);
        }
    }
}
