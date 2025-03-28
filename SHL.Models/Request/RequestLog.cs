using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Request
{
    public class RequestLog : BaseModel
    {
        public long UserId { get; set; }
        public int RequestTypeId { get; set; }
        public int ApprovalStatus { get; set; }
        public long ApprovalProcessId { get; set; }
        public DateTime? DateApproved { get; set; }
    }
}
