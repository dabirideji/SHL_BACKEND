using System.Collections.Generic;

namespace SHL.Domain.Models.Identity
{
    public class ApplicationPermission
    {

        public ApplicationPermission()
        {
            ApplicationRolePermissions = new HashSet<ApplicationRolePermission>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int ModuleID { get; set; }


        public virtual ICollection<ApplicationRolePermission> ApplicationRolePermissions { get; set; }

    }
}
