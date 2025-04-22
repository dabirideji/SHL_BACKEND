using Microsoft.AspNetCore.Identity;

namespace SHL.Application.TwoAuthenticatorProviders
{
    /// <summary>
    /// https://github.com/aspnet/Identity/blob/85f8a49aef68bf9763cd9854ce1dd4a26a7c5d3c/src/Core/TotpSecurityStampBasedTokenProvider.cs
    /// https://andrewlock.net/implementing-custom-token-providers-for-passwordless-authentication-in-asp-net-core-identity/
    /// </summary>
    public class TotpTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser> where TUser : class
    {

        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }
    }
}
