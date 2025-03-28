using System.Security.Claims;

namespace CSL.Models.Identity
{
    public class AppClaimsPrincipal : ClaimsPrincipal
    {
        public AppClaimsPrincipal(ClaimsPrincipal principal)
            : base(principal)
        { }

        public long UserId
        {
            get { return long.Parse(this.FindFirst(ClaimTypes.Sid).Value); }
        }
    }
}
