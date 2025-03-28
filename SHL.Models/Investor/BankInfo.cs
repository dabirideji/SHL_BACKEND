using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class BankInfo : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string BVN { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public long? BankId { get; set; }
        public bool? IsDefault { get; set; }


        public virtual BasicInfo BasicInfo { get; set; } 

    }
}
