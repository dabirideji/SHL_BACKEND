using Microsoft.AspNetCore.Identity;
using SHL.Domain.Models;
using static Dapper.SqlMapper;

namespace SHL.Api
{
    public class TotpTokenProvider : TotpSecurityStampBasedTokenProvider<CompanyUser>
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<CompanyUser> manager, CompanyUser user)
        {
            return Task.FromResult(false);
        }

        public override Task<string> GetUserModifierAsync(string purpose, UserManager<CompanyUser> manager, CompanyUser user)
        {
            return base.GetUserModifierAsync(purpose, manager, user);
        }


    }
}
