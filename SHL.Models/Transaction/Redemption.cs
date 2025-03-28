using CSL.Models.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Transaction
{
    public class Redemption : BaseModel
    {
        public long BasicInfoId { get; set; }
        public long AccountCode { get; set; }
        public string AccountName { get; set; }
        public Decimal SubscriptionAmount { get; set; }
        public Decimal UnitsHeld { get; set; }
        public Decimal UnitsToBeRedeemed { get; set; }
        public DateTime TransactionDate { get; set; } 
        public string BVN { get; set; } 
        public long CompanyRegCode { get; set; }
        public string CompanyName { get; set; }
        public bool? IsValidated { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string EncryptedOTP { get; set; }
        public DateTime? OtpExpiry { get; set; }
        public string OtpEmail { get; set; }
        public string OtpPhone { get; set; }
        public string Narration { get; set; }
        public string TransactionReference { get; set; } 


        public virtual BasicInfo BasicInfo { get; set; }
    }
}
