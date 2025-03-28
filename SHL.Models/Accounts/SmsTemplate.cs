using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSL.Models.Accounts
{
    public class SmsTemplate
    {
        public SmsTemplate()
        {
            Date_Created = DateTime.Now;
            Is_Deleted = false;
        }
        public int Id { get; set; }

        [Required]
        public string SmsHeader { get; set; }

        [Required]
        public string TextMessage { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Is_Deleted { get; set; }
        public string Updated_By { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime? Last_Date_Updated { get; set; }
        public string Deleted_By { get; set; }
        public string Created_By { get; set; }
        public int Sub_Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime? Date_Deleted { get; set; }
        public ICollection<SmsLog> SmsLog { get; set; }
    }
}
