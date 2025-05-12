using Microsoft.AspNetCore.Identity;

namespace SHL.Domain.Models.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<long>
    {
        public long Id { get; set; }
    }

}
