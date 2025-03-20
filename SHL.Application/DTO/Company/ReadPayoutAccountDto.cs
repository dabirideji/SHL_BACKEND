using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadPayoutAccountDto
    {

        public Guid Id { get; set; }
        public Guid PayoutAccountUserId { get; set; }
        public bool PayoutAccountIsVerified { get; set; }
        public string? PayoutAccountBankName { get; set; }
        public string? PayoutAccountIdentificationCode { get; set; }
        public PayoutAccountType? PayoutAccountAccountType { get; set; }
        public PayoutAccountStatus? PayoutAccountStatus { get; set; }
        public string? PayoutAccountAccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
