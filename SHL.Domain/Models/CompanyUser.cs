using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class CompanyUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string StaffStatus { get; set; } = default!;
        public bool IsAdmin { get; set; }
        public virtual Staff? Staff { get; set; }

    }
}
