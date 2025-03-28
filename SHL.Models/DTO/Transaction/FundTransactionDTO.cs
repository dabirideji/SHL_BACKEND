using CSL.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Transaction
{
    public class FundTransactionDTO 
    {
        public long BasicInfoId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public decimal UnitsAlloted { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Price { get; set; }
        public string BVN { get; set; }
        public string Status { get; set; }
        public string CompanyRegCode { get; set; }
        public string CompanyName { get; set; }
        public string Narration { get; set; }
        public string TransactionReference { get; set; }
    }

   
}
