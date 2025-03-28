using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class AutoRenewEventLog
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public string? Reference { get; set; }
        public string? Status { get; set; }
        public string? Email { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CustomerCode { get; set; }
        public string? SubscriptionCode { get; set; }

    }
}
