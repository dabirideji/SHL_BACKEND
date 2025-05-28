using System;

namespace SHL.Domain.Models
{


    public class SubscriptionPayment : BaseModel //subscription_payment
    {
        public bool IsPaid { get; set; }
        public int? PaymentTypeId { get; set; } // Represent PaymentType Enum: {}
        public string PaymentType { get; set; } // Represent PaymentType EnumName
        public DateTime? DatePaid { get; set; }
        public DateTime? Modified { get; set; }
        public long SubscriptionId { get; set; }
        public string TransactionReference { get; set; }
        public decimal AmountPaid { get; set; }
        public string Email { get; set; }

        public long PaymentLogId { get; set; }
        // Represent ShareholderId (i.e. UserVerification Id), Shareholder fullname
        public long? PaymentById { get; set; }
        public string PaymentBy { get; set; }

        public int? PaymentSource { get; set; }
  
        public virtual Subscription Subscription { get; set; }
        public virtual PaymentLog PaymentLog { get; set; }
    }
}
