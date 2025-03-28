using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Transaction
{
    public class RedemptionInputDTO
    {
        public long BasicInfoId { get; set; }
        public long AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public decimal UnitsToBeRedeemed { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BVN { get; set; }
        public long CompanyRegCode { get; set; } 
        public string CompanyName { get; set; }
        public string Narration { get; set; }
    }

    public class RedemptionOutputDTO : RedemptionInputDTO
    {
        public bool IsComplete { get; set; }
        public decimal UnitsHeld { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string TransactionReference { get; set; }
    }

    public class ValidateRRedemptionDTO
    {
        public string TransactionReference { get; set; }
        public string OTP { get; set; }
    }
}
