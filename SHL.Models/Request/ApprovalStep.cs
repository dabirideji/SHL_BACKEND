using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSL.Models.Request
{
    public class ApprovalStep: BaseModel
    {
        [Required]
        public long ApprovalProcessId { get; set; }
        [Required]
        public int StepSn { get; set; }
        [Required]
        public long PrivilegeId { get; set; }
        public long UserId { get; set; }

        //public int user_id { get; set; }
        [Required]
        public int Isnabled { get; set; }

        
        public virtual ICollection<ApprovalLog> ApprovalLogs { get; set; }
        public string StepType { get; set; }
        public string StepName { get; set; }
        [NotMapped]
        public string UserEmail { get; set; }
        public virtual ApprovalProcess ApprovalProcess { get; set; }
    }
}
