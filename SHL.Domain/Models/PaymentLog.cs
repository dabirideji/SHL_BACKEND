using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{

    public class PaymentInitiationLog
    {
        public PaymentInitiationLog()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public string PayRef { get; set; }
        public string PayLog { get; set; }
        public DateTime DateCreated { get; set; }
    }


    public class PaymentLog
    {
        public PaymentLog()
        {
            IsActive = true;
            IsDeleted = false;
            DateCreated = DateTime.Now;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ItemId { get; set; } // Represent Subscription etc

        public int PaymentTypeId { get; set; } // Represent PaymentType Enum: {}
        public string PaymentType { get; set; } // Represent PaymentType EnumName

        public bool Status { get; set; }
        public string Message { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionDate { get; set; }
        public string Reference { get; set; }
        public string Plan { get; set; }
        public string Domain { get; set; }
        public string Channel { get; set; }
        public string IPAddress { get; set; }
        public string AuthorizationCode { get; set; }
        public string CardType { get; set; }
        public string LastFourDigit { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public string Bin { get; set; }
        public string Bank { get; set; }
        public string Signature { get; set; }
        public string CountryCode { get; set; }
        public string AccountName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        //public string PlanCode { get; set; }
        //public string AuthorizationUrl { get; set; }
        //public string SubscriptionCode { get; set; }
    }
}
