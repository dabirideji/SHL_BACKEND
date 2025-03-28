using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSL.Models.Request
{
    [Table("ApprovalProcess")]
    public class ApprovalProcess: BaseModel
    {
        [StringLength(100)]
        public string Name { get; set; }
        public int IsSystem { get; set; }
        public bool? UseOTP { get; set; }
        public string Category { get; set; }
        public string FlowType { get; set; }
        public string PartialViewName { get; set; }

        public virtual ICollection<ApprovalLog> ApprovalLogs { get; set; }
        public virtual ICollection<ApprovalStep> ApprovalSteps { get; set; }
    }
    
}
