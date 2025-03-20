using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadOptionPoolDto
    {
        public Guid Id { get; set; }
        public Guid? OptionPoolCompanyId { get; set; }
        public string? OptionPoolName { get; set; }
        public double OptionPoolTotalShares { get; set; }
        public double OptionPoolTotalSharesAvailable { get; set; }
        public double OptionPoolTotalSharesVestable { get; set; }
        public OptionPoolStatus? OptionPoolStatus { get; set; }
        public OptionPoolApprovalStatus? OptionPoolApprovalStatus { get; set; }
        public OptionPoolType OptionPoolType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
