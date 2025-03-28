using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class Identification : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string IDNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string IssueAuthority { get; set; }
        public string Comment { get; set; }
        public bool IsDefault { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
