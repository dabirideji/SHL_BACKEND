using CSL.Models.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Transaction
{
    public class FundTransaction : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public Decimal SubscriptionAmount { get; set; }
        public Decimal UnitsAlloted { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Price { get; set; }
        public string BVN { get; set; }
        public string Status { get; set; }
        public string CompanyRegCode { get; set; }
        public string CompanyName { get; set; }
        public string TransactionReference { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
