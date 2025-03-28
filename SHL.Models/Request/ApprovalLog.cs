using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSL.Models.Request
{
    public class ApprovalLog: BaseModel
    {
        [Required]
        public long ApprovalProcessId { get; set; }
        [Required]
        public int StepSn { get; set; }
        [Required]
        public long ItemId { get; set; }
        public long? UserId { get; set; }
        [Required]
        public long PrivilegeId { get; set; }
        public int? ReviewStatus { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? NotifyDate { get; set; }

        [StringLength(1000)]
        public string ReviewedBy { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        [NotMapped]
        public string Base64str { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }
        public string OTP { get; set; }
        public DateTime? OTP_ExpiryDate { get; set; }
        public decimal? ApprovalAmount { get; set; }
        public string StepLabel { get; set; }


        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public bool isRequestType { get; set; }

        public virtual ApprovalProcess ApprovalProcess { get; set; }
    }


    public partial class ApprovalLogHistory
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long ApprovalProcessId { get; set; }
        [Required]

        public int StepSn { get; set; }
        [Required]
        public long ItemId { get; set; }
        public long? UserId { get; set; }
        [Required]
        public long PrivilegeId { get; set; }
        public int? ReviewStatus { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? NotifyDate { get; set; }

        [StringLength(1000)]
        public string ReviewedBy { get; set; }
        public string FileName { get; set; }

        public string FilePath { get; set; }


        [StringLength(1000)]
        public string Comment { get; set; }
        public int CompanyID { get; set; }
        public int SubID { get; set; }
    }

    public class CallbackLog
    {
        [Key]
        public long Id { get; set; }
        public long ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public long ItemId { get; set; }
        public long CompanyId { get; set; }
        public long SubId { get; set; }
        public string CallBackUrl { get; set; }
        public bool IsProcessed { get; set; }
        public string Payload { get; set; }
        public DateTime? DateProcessed { get; set; }
        public bool? CallbackStatus { get; set; }
        public string CallbackData { get; set; }
    }
}
