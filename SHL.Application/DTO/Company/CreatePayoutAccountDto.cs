using System.ComponentModel.DataAnnotations;

namespace SHL.Application.DTO.Company.Request
{
    public class CreatePayoutAccountDto
    {
        [Required]
        public Guid PayoutAccountUserId { get; set; }
        [Required]
        public string? PayoutAccountBankName { get; set; }
        [Required]
        public string? PayoutAccountIdentificationCode { get; set; }
        [Required]
        public string? PayoutAccountAccountNumber { get; set; }
    }
}
