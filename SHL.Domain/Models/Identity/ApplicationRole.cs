using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SHL.Domain.Models.Identity
{

    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole()
        {
            ApplicationRolePermissions = new HashSet<ApplicationRolePermission>();
        }


        public string Description { get; set; }
        public bool IsSystemRole { get; set; }

        public virtual ICollection<ApplicationRolePermission> ApplicationRolePermissions { get; set; }
    }

}
