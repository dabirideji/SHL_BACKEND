using Microsoft.AspNetCore.Identity;

namespace SHL.Domain.Models.Identity
{
    public class ApplicationUserRole : IdentityUserRole<long>
    {
        public long Id { get; set; }
    }
}
