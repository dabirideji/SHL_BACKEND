using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CSL.Models.Identity
{

    public class ApplicationUser : IdentityUser<long>
    {

        public ApplicationUser()
        {
            UserDevices = new HashSet<UserDevice>();
        }

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


        public virtual ICollection<UserDevice> UserDevices { get; set; }

    }

}