using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class PayoutAccount : BaseEntity
    {
        [ForeignKey("PayoutAccountUser")]
        public Guid PayoutAccountUserId { get; set; }
       // public User? PayoutAccountUser { get; set; }
        public bool PayoutAccountIsVerified { get; set; } = false;
        public string? PayoutAccountBankName { get; set; }
        public string? PayoutAccountIdentificationCode { get; set; }
        public PayoutAccountType? PayoutAccountAccountType { get; set; } = PayoutAccountType.BUSINESS;
        public PayoutAccountStatus? PayoutAccountStatus { get; set; } = Categories.PayoutAccountStatus.PENDING;
        public string? PayoutAccountAccountNumber { get; set; }
    }
}