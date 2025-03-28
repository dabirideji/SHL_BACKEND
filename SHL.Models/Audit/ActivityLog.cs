using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Audit
{
    public class ActivityLog :BaseModel
    {
        public long ActorUserId { get; set; }
        public string ActorName { get; set; }
        public string ActionType { get; set; }
        public string Module { get; set; }
        public string Details { get; set; }
        public long ActionItemId { get; set; }
        public string Source { get; set; }
    }
}
