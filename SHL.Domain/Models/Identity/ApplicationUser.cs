using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SHL.Domain.Models.Identity
{

    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTenantAdmin { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? LastLogin { get; set; }
        public int CompanyId { get; set; }
        public int SubsidiaryId { get; set; }
        public string Token { get; set; }
        public string ApiSessionId { get; set; }
        public string LastComputerName { get; set; }


    }

}