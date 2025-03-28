using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class AutoRenewInvoice
    {
        public int Id { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? Status { get; set; }
        public string? CustomerEmail { get; set; }       
        public decimal? AmountPaid { get; set; }       
        public string? SubscriptionCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Reference { get; set; }
        public string? LastFailureReason { get; set; }
        public DateTime? LastFailedAt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PlanCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BankName { get; set; }
        public string? Description { get; set; }
        public string? CustomerCode { get; set; }
        public string? Bank { get; set; }
        public string? AccountName { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public string? SubscriptionStatus { get; set; }
        public bool IsAutoRenew { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
