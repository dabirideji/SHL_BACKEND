using Microsoft.AspNetCore.Identity;
using SHL.Domain.Models;
using SHL.Domain.Models.Identity;
using static Dapper.SqlMapper;

namespace SHL.Api
{
    public class TotpTokenProvider : TotpSecurityStampBasedTokenProvider<ApplicationUser>
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            return Task.FromResult(false);
        }

        public override Task<string> GetUserModifierAsync(string purpose, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            return base.GetUserModifierAsync(purpose, manager, user);
        }


    }
}
