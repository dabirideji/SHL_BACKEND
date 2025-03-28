using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwUserPrivilege
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long PrivilegeID { get; set; }
        public long RoleId { get; set; }
        public int CompanyId { get; set; }
    }
}
