using Microsoft.AspNetCore.Identity;

namespace CSL.Models.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
        public long ApplicationRoleId { get; set; }
        public long ApplicationClaimId { get; set; }
    }
}
