using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSL.Models.Accounts
{
    public class SmsLog
    {
        public SmsLog()
        {
            Is_Active = false;
            Is_Deleted = false;
            DateCreated = DateTime.Now;
            Is_Sent = false;
            FailedCount = 0;
            SentCount = 0;
        }
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public DateTime DateToSend { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int SubId { get; set; }

        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PhoneNumber { get; set; }

        public string Deleted_By { get; set; }
        public string Created_By { get; set; }
        public long? EmployeeId { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Date_Deleted { get; set; }
        public DateTime? Last_Date_Updated { get; set; }
        public bool Is_Sent { get; set; }
        public DateTime? Date_Sent { get; set; }
        public long SentCount { get; set; }
        public long FailedCount { get; set; }
        //[ForeignKey(nameof(SearchId))]
        //public int SearchId { get; set; }

        //public SearchCriteria Search { get; set; }

        public int? templateId { get; set; }
        //[ForeignKey(nameof(templateId))]
        public SmsTemplate SmsTemplate { get; set; }
        public int SearchId { get; set; }
    }
}
