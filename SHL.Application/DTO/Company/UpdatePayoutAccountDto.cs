using System.ComponentModel.DataAnnotations;
using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdatePayoutAccountDto
    {
        [Required]
        public string? PayoutAccountBankName { get; set; }
        [Required]
        public string? PayoutAccountIdentificationCode { get; set; }
        [Required]
        public PayoutAccountStatus? PayoutAccountStatus { get; set; }
        [Required]
        public string? PayoutAccountAccountNumber { get; set; }
    }
}
