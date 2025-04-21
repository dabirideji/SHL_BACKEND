using Microsoft.AspNetCore.Identity;

namespace SHL.Domain.Models.Identity
{
    public class ApplicationUserToken : IdentityUserToken<long>
    {
        public long Id { get; set; }
    }
}
