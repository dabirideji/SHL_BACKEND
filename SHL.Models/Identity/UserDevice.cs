using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Identity
{
    public class UserDevice : BaseModel
    {
        public long UserId { get; set; }
        public string DeviceId { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
    }


}
