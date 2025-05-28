using System.ComponentModel.DataAnnotations;
using SHL.Domain.Models.Identity;

namespace SHL.Domain.Models
{
    public class UserVerification
    {
        [Key]
        public long Id { get; set; }
        public int DefaultCompanyId { get; set; }
        public int DefaultAcctNo { get; set; }
        public string ApplicationUserId { get; set; }
        public string? CustomerNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Holder_type { get; set; }
        public string? BVN { get; set; }
        public string? NIN { get; set; }
        public string? TIN { get; set; }
        public string? RC_No { get; set; }
        public string? Email { get; set; }
        public string? Phone_no { get; set; }
        public string? Password { get; set; }
        public bool Email_Verified { get; set; }
        public bool Phone_Verified { get; set; }
        public DateTime? EmailVerifyDate { get; set; }
        public DateTime? PhoneVerifyDate { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public bool IsTokenExpired { get; set; }
        public long? SubscriptionId { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public bool IsFreeMode { get; set; }
        public bool IsSent { get; set; }
        public bool IsNotify { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsSynched { get; set; }
        public bool? IsPolicyAccepted { get; set; }
        public bool? ToggleNotification { get; set; }
        public string? Source { get; set; }
        public string? InfoUpdateStatus { get; set; }
        public string? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }

}
