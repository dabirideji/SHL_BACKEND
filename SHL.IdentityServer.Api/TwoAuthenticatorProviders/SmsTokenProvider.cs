using Microsoft.AspNetCore.Identity;

namespace SHL.IdentityServer.Api.TwoAuthenticatorProviders
{
    public class SmsTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser> where TUser : class
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(true);
        }
    }
}
